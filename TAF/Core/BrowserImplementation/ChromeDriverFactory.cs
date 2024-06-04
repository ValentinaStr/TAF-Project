using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.DriverImplementation
{
    public class ChromeDriverFactory : IDriverFactory
    {
        public IWebDriver Get(string defaultDownloadDirectory, bool headless)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddUserProfilePreference("download.default_directory", defaultDownloadDirectory);

            if (headless)
            {
                chromeOptions.AddArgument("--headless");
            }

            var service = ChromeDriverService.CreateDefaultService();
            return new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(3));
        }
    }
}
