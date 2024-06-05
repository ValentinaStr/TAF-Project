using Core.Utilits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Core.DriverImplementation
{
    public class WebElementActions 
    {
        private readonly WebDriverWait wait;

        public WebElementActions(WebDriverWait wait)
        {
            this.wait = wait;
        }

        public void Click(By by)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
                element.Click();
                Logger.LogInfo($"Clicked on element located by: {by}");
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for element to be clickable: {by}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError(ex, $"Element not found: {by}");
                throw;
            }
        }

        public void EnterText(By by, string text)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                element.Clear();
                element.SendKeys(text);
                Logger.LogInfo($"Entered text '{text}' into element located by: {by}");
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for element to be visible: {by}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError(ex, $"Element not found: {by}");
                throw;
            }
        }

        public string GetText(By by)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                Logger.LogInfo($"Retrieved text '{element.Text}' from element located by: {by}");
                return element.Text;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for element to be visible: {by}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError(ex, $"Element not found: {by}");
                throw;
            }
        }

        public IWebElement GetElement(By by)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementExists(by));
                Logger.LogInfo($"Found element located by: {by}");
                return element;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for element to exist: {by}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError(ex, $"Element not found: {by}");
                throw;
            }
        }

        public void ClickChildElement(IWebElement parentElement, By childLocator)
        {
            try
            {
                parentElement.FindElement(childLocator).Click();
                Logger.LogInfo($"Clicked on child element located by: {childLocator}");
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for child element to be clickable: {childLocator}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError(ex, $"Child element not found: {childLocator}");
                throw;
            }
        }

        public void ClickEnter(By by)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
                element.SendKeys(Keys.Enter);
                Logger.LogInfo($"Sent 'Enter' key to the element located by: {by}");
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError(ex, $"Timed out waiting for the element to be clickable: {by}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError(ex, $"Element not found: {by}");
                throw;
            }
        }
    }
}