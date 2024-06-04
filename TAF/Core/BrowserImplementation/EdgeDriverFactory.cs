using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Core.DriverImplementation
{
    public class EdgeDriverFactory : IDriverFactory
    {
        public IWebDriver Get(string defaultDownloadDirectory, bool headless)
        {
            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            edgeOptions.AddArgument("window-size=1920,1080");
            edgeOptions.AddArgument("disable-extensions");
            edgeOptions.AddArgument("disable-gpu");
            edgeOptions.AddUserProfilePreference("download.default_directory", defaultDownloadDirectory);

            if (headless)
            {
                edgeOptions.AddArgument("--headless");
            }

            var service = EdgeDriverService.CreateDefaultService();
            return new EdgeDriver(service, edgeOptions, TimeSpan.FromMinutes(3));
        }
    }
}
