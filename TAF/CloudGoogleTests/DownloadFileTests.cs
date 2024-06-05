namespace CloudGoogleTests
{
    [TestFixture]
    internal class DownloadFileTests : BaseTest
    {
        public static IEnumerable<object[]> DataForTestFileDownload => TestDataReader<DataModelForDownloadFileTests>.GetTestData("DataForTestFileDownload.json").Select(data => new object[] { data });

        [Test]
        [TestCaseSource(nameof(DataForTestFileDownload))]
        public void ValidateFileDownloadFunctionWorksExpectedPositive(DataModelForDownloadFileTests DataForTestFileDownload)
        {
            var fileName = DataForTestFileDownload.FileName;
            homePageForTests.AddTextToSearchField("Google Cloud Platform Pricing Calculator");

            var surchResultPage = homePageForTests.OpenSurchResult();
            var welcomePricingCalculatorPage = surchResultPage.ClickPricingCalculatorLink();
            welcomePricingCalculatorPage.ClickAddToEstimateButton();
            var computeEnginePage = welcomePricingCalculatorPage.ClickComputeEngineItem();

            computeEnginePage.AddNumberOfInstances(4);
            computeEnginePage.SelectMachineType("n1-standard-8");
            computeEnginePage.AddGPUsType("nvidia-tesla-p100");
            computeEnginePage.ChooseAddLocalSSD("2");
            computeEnginePage.DownloadEstimateCsv();
            computeEnginePage.WaitForFileDownload(defaultDownloadDirectory, ".csv");

            var result = FileAndDirectoryHelper.CheckFileExistenceWithExtension(defaultDownloadDirectory, fileName);

            Assert.That(result, Is.True, $"File {fileName} download failed");
        }

    }
}
