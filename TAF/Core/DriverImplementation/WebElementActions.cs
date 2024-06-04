using Core.Utilits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Core.DriverImplementation
{
    internal class WebElementActions
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
    }
}