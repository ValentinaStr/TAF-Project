namespace CloudGoogleTests
{
    [TestFixture]
    internal class DownloadFileTests : BaseTest
    {
        public static IEnumerable<object[]> DataForTestFileDownload => TestDataReader<DataModelForDownloadFileTest>.GetTestData("DataForTestFileDownload.json").Select(data => new object[] { data });

        [Test]
        [TestCaseSource(nameof(DataForTestFileDownload))]
        public void ValidateFileDownloadFunctionWorksExpectedPositive(DataModelForDownloadFileTest testData)
        {
            homePageForTests.AddTextToSearchField(testData.TextToSearchField);
            var surchResultPage = homePageForTests.OpenSearchResult();
            var welcomePricingCalculatorPage = surchResultPage.ClickPricingCalculatorLink();
            welcomePricingCalculatorPage.ClickAddToEstimateButton();
            var computeEnginePage = welcomePricingCalculatorPage.ClickComputeEngineItem();
            computeEnginePage.AddNumberOfInstances(testData.NumberOfInstances);
            computeEnginePage.SelectMachineType(testData.MachineType);
            computeEnginePage.AddGPUsType(testData.GPUsType);
            computeEnginePage.ChooseAddLocalSSD(testData.LocalSSD);
            computeEnginePage.DownloadEstimateCsv();
            computeEnginePage.WaitForFileDownload(defaultDownloadDirectory, testData.FileName);

            var result = FileAndDirectoryHelper.CheckFileExistenceWithExtension(defaultDownloadDirectory, testData.FileName);

            Assert.That(result, Is.True, $"File {testData.FileName} download failed");
        }
    }
}
