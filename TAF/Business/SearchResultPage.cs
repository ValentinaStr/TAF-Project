namespace Business
{
    public class SearchResultPage : BasePage
    {
        protected readonly By PricingCalculator = By.CssSelector("a.gs-title[href*='cloud.google.com/products/calculator']");
        protected readonly By ListOfSearch = By.CssSelector(".gsc-expansionArea .gsc-webResult");

        public SearchResultPage(DriverActions driverAction) : base(driverAction)
        {
        }

        public WelcomePricingCalculatorPage ClickPricingCalculatorLink()
        {
            driverAction.FindElementWithWaiterAndClick(PricingCalculator);
            return new WelcomePricingCalculatorPage(driverAction);
        }

        public IEnumerable<IWebElement> GetLitsOfSearch()
        {
            return driverAction.FindElementsWithWaiter(ListOfSearch);
        }
    }
}