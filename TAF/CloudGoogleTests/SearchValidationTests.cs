namespace CloudGoogleTests
{
    internal class SearchValidationTests : BaseTest
    {
        public static IEnumerable<object[]> DataSearchValidationeTest => TestDataReader<DataModelForSearchValidationTest>.GetTestData("DataForPositiveTestSearchValidation.json").Select(data => new object[] { data });


        [Test]
        [TestCaseSource(nameof(DataSearchValidationeTest))]
        public void SearchValidationPositive(DataModelForSearchValidationTest testData)
        {
            homePageForTests.AddTextToSearchField(testData.TextToSearchField);
            var surchResultPage = homePageForTests.OpenSurchResult();
            var listOfSearch = surchResultPage.GetLitsOfSearch();

            var allResultsContainText = listOfSearch.All(element => element.Text.Contains(testData.TextToSearchField));

            Assert.IsTrue(allResultsContainText, $"Not all search results contain the expected text {testData.TextToSearchField}.");
        }
    }
}
