using API;
using API.Model.RequestModels;
using API.Model.ResponseModels;
using Core.Utilits;
using FluentAssertions.Execution;
using NUnit.Framework.Interfaces;
using RestSharp;
using System.Net;

namespace TestsAPI
{
    [TestFixture]
    public class APITests
    {
        public  RequestBuilder TestRequestBuilder;
        public const string Url = "https://jsonplaceholder.typicode.com/users";

        [SetUp]
        public void Setup()
        {
            Logger.LogInfo($"Start test {TestContext.CurrentContext.Test.Name}");
            TestRequestBuilder = new RequestBuilder();
        }

        [TearDown]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Logger.LogInfo($"Test {TestContext.CurrentContext.Test.Name} failed");
            }

            TestRequestBuilder.Dispose();

            Logger.LogInfo($"Test {TestContext.CurrentContext.Test.Name} finished");
        }

        [Test]
        [Category("API")]
        public void ValidateThatListOfUsersCanBeReceivedSuccessfully()
        {
            TestRequestBuilder.WithUrl(Url);
            RestResponse response = TestRequestBuilder.WithHeader("Accept", "application/json").SendGet();
            var content = ResponceDeserializer.DeserializeResponse<List<UserDataResponceModel>>(response);

            var result = content.All(user =>
                      user.Id != 0 &&
                      !string.IsNullOrEmpty(user.Name) &&
                      !string.IsNullOrEmpty(user.Username) &&
                      !string.IsNullOrEmpty(user.Email) &&
                      user.Address != null &&
                      !string.IsNullOrEmpty(user.Phone) &&
                      !string.IsNullOrEmpty(user.Website) &&
                      user.Company != null &&
                      !string.IsNullOrEmpty(user.Company.Name));

            using (new AssertionScope())
            {
                Assert.That(result, Is.True);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }

        [Test]
        [Category("API")]
        public void ValidateResponseHeaderForListOfUsers()
        {
            RestResponse response =
                TestRequestBuilder.WithUrl(Url).WithHeader("Accept", "application/json").SendGet();

            var contentTypeHeader = response.ContentHeaders.FirstOrDefault(h => h.Name.Equals("Content-Type", StringComparison.OrdinalIgnoreCase)).Value.ToString();

            using (new AssertionScope())
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(contentTypeHeader, Is.EqualTo("application/json; charset=utf-8"));
            }
        }

        [Test]
        [Category("API")]
        public void ValidateResponseBodyForListOfUsers()
        {
            RestResponse response = TestRequestBuilder.WithUrl(Url).WithHeader("Accept", "application/json").SendGet();

            var content = ResponceDeserializer.DeserializeResponse<List<UserDataResponceModel>>(response);

            bool allDifferent = content.Count == content.Select(x => x.Id).Distinct().Count();
            var allUsersHaveNonEmptyNameAndUsername = content.All(x => x.Name != null && x.Username != null);
            var allUsersHaveNonEmptyCompanyName = content.All(x => x.Company.Name != null);

            using (new AssertionScope())
            {
                Assert.That(allDifferent, Is.True);
                Assert.That(allUsersHaveNonEmptyNameAndUsername, Is.True);
                Assert.That(allUsersHaveNonEmptyCompanyName, Is.True);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }

        [Test]
        [Category("API")]
        public void ValidateThatUserCanBeCreated()
        {
            var userPost = new UserRequestModel("123", "qwe");

           var response  = TestRequestBuilder.WithUrl(Url).WithHeader("Accept", "application/json").
                WithPostData(userPost).SendPost();

            var content = ResponceDeserializer.DeserializeResponse<IDResponceModel>(response);

            using (new AssertionScope())
            {
                Assert.That(content, Is.Not.Null);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            }
        }

        [Test]
        public void ValidateThatUserNotifiedIfResourceDoesNotExist()
        {
            TestRequestBuilder.WithUrl("https://jsonplaceholder.typicode.com/invalidendpoint").WithHeader("Accept", "application/json");
            var response = TestRequestBuilder.SendGet();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
