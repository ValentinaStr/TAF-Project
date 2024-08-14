using Core.Utils;

namespace CloudGoogleTests
{
    internal class SearchValidationTests : BaseTest
    {
        public static IEnumerable<object[]> DataSearchPositiveTest =>
            TestDataReader<DataModelForPositiveSearchValidationTest>.GetTestData("DataForPositiveTestSearchValidation.json")
            .Select(data => new object[] { data });

        public static IEnumerable<object[]> DataSearchNegativeTest =>
            TestDataReader<DataModelForNegativeTestSearchValidation>.GetTestData("DataForNegativeTestSearchValidation.json")
            .Select(data => new object[] { data });

        public static IEnumerable<object[]> DataSearchEmptyTest =>
            TestDataReader<DataModelForNegativeTestSearchValidation>.GetTestData("DataForNegativeTestSearchValidationEmpty.json")
            .Select(data => new object[] { data });

        [Test]
        [TestCaseSource(nameof(DataSearchPositiveTest))]
        public void ValidateSearchPositive(DataModelForPositiveSearchValidationTest testData)
        {
            homePageForTests.AddTextToSearchField(testData.TextToSearchField);
            var searchResultPage = homePageForTests.OpenSearchResult();
            var listOfSearch = searchResultPage.GetListOfSearch();

            var allResultsContainText = listOfSearch.All(element => element.Text.Contains(testData.TextToSearchField));

            Assert.IsTrue(allResultsContainText, $"Not all search results contain the expected text {testData.TextToSearchField}.");
        }

        [Test]
        [TestCaseSource(nameof(DataSearchNegativeTest))]
        public void ValidateSearchNegative(DataModelForNegativeTestSearchValidation testData)
        {
            string textToSearchField = RandomStringGenerator.GenerateRandomAlphaWithSpecialSymbolString(50);
            homePageForTests.AddTextToSearchField(textToSearchField);
            var searchResultPage = homePageForTests.OpenSearchResult();

            var actual = searchResultPage.GetTextNegativeSearch();

            Assert.That(actual, Is.EqualTo(testData.ExpectedResponse), $"Actual response '{actual}' did not match the expected response '{testData.ExpectedResponse}' for input '{textToSearchField}'.");
        }

        [Test]
        [TestCaseSource(nameof(DataSearchEmptyTest))]
        public void ValidateEmptySearchNegative(DataModelForNegativeTestSearchValidation testData)
        {
            homePageForTests.AddTextToSearchField("");
            var searchResultPage = homePageForTests.OpenSearchResult();

            var actual = searchResultPage.GetTextEmptySearch();

            Assert.That(actual, Is.EqualTo(testData.ExpectedResponse), $"Actual response '{actual}' did not match the expected response '{testData.ExpectedResponse}' for empty input.");
        }
    }
}
