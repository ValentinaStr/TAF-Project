namespace Business
{
    public class SearchResultPage : BasePage
    {
        protected readonly By PricingCalculator = By.CssSelector("a.gs-title[href*='cloud.google.com/products/calculator']");

        public SearchResultPage(DriverActions driverAction) : base(driverAction)
        {
        }

        public WelcomePricingCalculatorPage ClickPricingCalculatorLink()
        {
            driverAction.FindElementWithWaiterAndClick(PricingCalculator);
            return new WelcomePricingCalculatorPage(driverAction);
        }
    }
}