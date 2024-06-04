using Core.DriverImplementation;
using OpenQA.Selenium;

namespace Business
{
    public class SearchResultPage : BasePage
    {
        protected readonly By PricingCalculator = By.CssSelector("a.gs-title[href*='cloud.google.com/products/calculator']");

        public SearchResultPage(DriverActions driverAction) : base(driverAction)
        {
        }

        public WelcomePricingCalculator ClickPricingCalculatorLink()
        {
            driverAction.FindElementWithWaiterAndClick(PricingCalculator);
            return new WelcomePricingCalculator(driverAction);
        }
    }
}
