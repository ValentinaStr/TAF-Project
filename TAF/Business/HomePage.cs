using Core.DriverImplementation;
using OpenQA.Selenium;

namespace Business
{
    public class HomePage : BasePage
    {
        private readonly By SearchIcon = By.CssSelector("div.YSM5S");
        private readonly By SearchField = By.CssSelector("input.mb2a7b");
        private readonly By PricingCalculatorLink = By.XPath("//a[contains(text(),'Google Cloud Platform Pricing Calculator')]");

        public HomePage(DriverActions driverActions) : base(driverActions)
        {
            driverAction.GoToUrl(TestRunSettings.Instance.Url);
        }

        public SearchResultPage OpenSurchResult()
        {
            driverAction.FindElementWithWaiterAndClick(SearchField);
            return new SearchResultPage(driverAction);
        }

        public void AddTextToSearchField(string text)
        {
            driverAction.FindElementWithWaiterAndEnterText(SearchField, text);
        }
    }
}
