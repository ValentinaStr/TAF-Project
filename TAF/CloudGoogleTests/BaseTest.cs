using NUnit.Framework.Interfaces;

namespace CloudGoogleTests
{
    public class BaseTest
    {
        public readonly string defaultDownloadDirectory = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Downloads");
        protected HomePage homePageForTests { get; set; }
        protected TestContext? testContext;
        protected DriverActions driverActionForTests;
        TestRunSettings settings = TestRunSettings.Instance;

        public TestContext TestContext
        {
            get
            {
                if (testContext != null)
                    return testContext;
                else
                    throw new InvalidOperationException("TestContext is null.");
            }
            set { testContext = value; }
        }

        [SetUp]
        public void BeforeTest()
        {
            driverActionForTests = new DriverActions(defaultDownloadDirectory, settings.Browser, settings.Headless);
            homePageForTests = new HomePage(driverActionForTests);
            FileAndDirectoryHelper.ClearDefaultDownloadDirectory(defaultDownloadDirectory);
            Logger.LogInfo($"Start test {TestContext.CurrentContext.Test.Name} ");
        }

        [TearDown]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Logger.LogInfo($"Test {TestContext.CurrentContext.Test.Name} failed");
                driverActionForTests.GetTimeNowScreenshot();
            }

            Logger.LogInfo($"Test {TestContext.CurrentContext.Test.Name} finished");
            driverActionForTests.Dispose();
        }
    }
}
