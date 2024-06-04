using Core.BrowserImplementation;
using Core.DriverImplementation;
using OpenQA.Selenium;

namespace EmailWebDriver
{
    public class DriverFactory
    {
        private static IDriverFactory? driver;
        private DriverFactory() { }
        public static IWebDriver GetDriver(string defaultDownloadDirectory, BrowserType browserType, bool headless = false)
        {
            if (driver == null)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        driver = new ChromeDriverFactory();
                        break;
                    case BrowserType.Firefox:
                        driver = new FirefoxDriverFactory();
                        break;
                    case BrowserType.Edge:
                        driver = new EdgeDriverFactory();
                        break;
                    default:
                        driver = new ChromeDriverFactory();
                        break;
                }
            }

            return driver.Get(defaultDownloadDirectory, headless);
        }
    }
}