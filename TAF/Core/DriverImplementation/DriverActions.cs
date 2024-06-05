using Core.BrowserImplementation;
using Core.Utilits;
using EmailWebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Core.DriverImplementation
{
    public class DriverActions : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Actions action;
        public readonly WebElementActions webElementActions;

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
            new Actions(driver).SendKeys(Keys.PageDown).Build().Perform();
        }

        public void ScrollUp()
        {
            new Actions(driver).SendKeys(Keys.PageUp).Build().Perform();
        }


        public void SelectValueInDropdownByCssSelector(By by, string value)
        {
            var dropDown = webElementActions.GetElement(by);
            string selector = $"li[data-value='{value}']";
            webElementActions.ClickChildElement(dropDown, By.CssSelector(selector));
        }

        public void SelectValueInDropdownByXPath(By by, string value)
        {
            var dropDown = webElementActions.GetElement(by);
            string xpath = $"//li[@data-value='{value}']";
            webElementActions.ClickChildElement(dropDown, By.XPath(xpath));
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

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void ClickEnter(By by)
        {
            webElementActions.ClickEnter(by);
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

        public void WaitForFileDownload(string defaultDownloadDirectory, string fileExtension)
        {
            try
            {
                wait.Until(drv => Directory.Exists(defaultDownloadDirectory));
                string[] files = Directory.GetFiles(defaultDownloadDirectory, $"*.{fileExtension}");
                wait.Until(drv => files.Any());
                Logger.LogInfo($"At least one file with '{fileExtension}' extension was successfully downloaded to '{defaultDownloadDirectory}'.");
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for a file with '{fileExtension}' extension to be downloaded.");
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

        public void HideCookieNotification()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementsByClassName('glue-cookie-notification-bar')[0].style.display = 'none';");
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}