using Core.BrowserImplementation;
using Core.Utilits;
using EmailWebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace Core.DriverImplementation
{
    public class DriverActions : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Actions action;
        private readonly WebElementActions webElementActions;

        public DriverActions(string defaultDownloadDirectory, BrowserType browserType, bool headless = false)
        {
            driver = DriverFactory.GetDriver(defaultDownloadDirectory, browserType, headless);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestRunSettings.Instance.WebDriverTimeOut));
            action = new Actions(driver);
            webElementActions = new WebElementActions(wait);
        }

        public void GoToUrl(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            driver.Url = url;
            Logger.LogInfo($"Open {url}");
        }

        public void ScrollToElement(By by)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            action.MoveToElement(driver.FindElement(by)).Perform();
            Logger.LogInfo($"Scroll to element {by}");
        }

        public void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void FindElementWithWaiterAndClick(By by)
        {
            webElementActions.Click(by);
        }

        public void FindElementWithWaiterAndEnterText(By by, string text)
        {
            webElementActions.EnterText(by, text);
        }

        public string FindElementWithWaiterAndGetText(By by)
        {
            return webElementActions.GetText(by);
        }

        public ReadOnlyCollection<IWebElement> FindElementsWithWaiter(By by)
        {
            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public bool CheckPresenceWordOnThePage(string word)
        {
            try
            {
                bool wordPresent = driver.PageSource.Contains(word, StringComparison.OrdinalIgnoreCase);
                if (wordPresent)
                {
                    Logger.LogInfo($"Page contains '{word}'.");
                }
                else
                {
                    Logger.LogInfo($"Page does not contain '{word}'.");
                }

                return wordPresent;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"An error occurred while checking presence of '{word}' on the page.");
                return false;
            }
        }

        public List<IWebElement> GetAllElementsWithWaiter(By locator)
        {
            try
            {
                var allElements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator)).ToList();
                Logger.LogInfo($"Found {allElements.Count()} elements with locator: {locator}.");
                return allElements;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for elements with locator: {locator}.");
                return new List<IWebElement>();
            }
        }

        public void WaitForFileDownload(string defaultDownloadDirectory, string fileName)
        {
            try
            {
                wait.Until(drv => FileAndDirectoryHelper.CheckFileExistence(defaultDownloadDirectory, fileName));
                Logger.LogInfo($"File '{fileName}' was successfully downloaded to '{Path.Combine(defaultDownloadDirectory, fileName)}'.");
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for file '{fileName}' to be downloaded.");
            }
        }

        public void GetTimeNowScreenshot()
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile($"{DateTime.Now:yyyyMMdd-HHmmss}.png");
                Logger.LogInfo($"Screenshot taken at {DateTime.Now:yyyyMMdd-HHmmss}.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while taking screenshot.");
            }
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}