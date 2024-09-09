using API;
using Core.Utilits;
using NUnit.Framework.Interfaces;

namespace TestsAPI
{
    [TestFixture]
    public class BaseAPITest
    {
        public RequestBuilder TestRequestBuilder;
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
    }
}
