namespace CloudGoogleTests
{
    [TestFixture]
    internal class HomePageTests : BaseTest
    {
        public static IEnumerable<object[]> DataForHomePageTests => TestDataReader<DataModelForLanguageChangeReflectsInNavigationMenuHomePageTest>.GetTestData("DataForTestLanguageChangeReflectsInNavigationMenuHomePage.json").Select(data => new object[] { data });

        [Test]
        [TestCaseSource(nameof(DataForHomePageTests))]
        public void VerifyLanguageChangeReflectsInNavigationMenuPositive(DataModelForLanguageChangeReflectsInNavigationMenuHomePageTest testData)
        {
            homePageForTests.ChangeLanguage(testData.Language);

            string menu = homePageForTests.GetNavigationMenuHeaderText();

            using (new AssertionScope())
            {
                string message = $"Menu in {testData.Language} language does not contain expected text: ";

                Assert.That(menu, Does.Contain(testData.Overview), message + testData.Overview);
                Assert.That(menu, Does.Contain(testData.Solutions), message + testData.Solutions);
                Assert.That(menu, Does.Contain(testData.Products), message + testData.Products);
                Assert.That(menu, Does.Contain(testData.Pricing), message + testData.Pricing);
                Assert.That(menu, Does.Contain(testData.Resources), message + testData.Resources);
                Assert.That(menu, Does.Contain(testData.ContactUs), message + testData.ContactUs);
                Assert.That(menu, Does.Contain(testData.Docs), message + testData.Docs);
                Assert.That(menu, Does.Contain(testData.Support), message + testData.Support);
                Assert.That(menu, Does.Contain(testData.SignIn), message + testData.SignIn);
                Assert.That(menu, Does.Contain(testData.StartFree), message + testData.StartFree);
            }
        }

    }
}