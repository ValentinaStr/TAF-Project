using OpenQA.Selenium;

namespace Core.DriverImplementation
{
    internal interface IDriverFactory
    {
        IWebDriver Get(string defaultDownloadDirectory, bool headless = false);
    }
}