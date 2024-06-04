using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Core.DriverImplementation
{
    public class FirefoxDriverFactory : IDriverFactory
    {
        public IWebDriver Get(string defaultDownloadDirectory, bool headless)
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("-headless");
            firefoxOptions.AddArgument("-user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            firefoxOptions.AddArgument("-window-size=1920,1080");
            firefoxOptions.AddArgument("-disable-extensions");
            firefoxOptions.AddArgument("-disable-gpu");

            if (headless)
            {
                firefoxOptions.AddArgument("--headless");
            }

            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("browser.download.default_directory", defaultDownloadDirectory);

            var service = FirefoxDriverService.CreateDefaultService();
            return new FirefoxDriver(service, firefoxOptions, TimeSpan.FromMinutes(3));
        }
    }
}
