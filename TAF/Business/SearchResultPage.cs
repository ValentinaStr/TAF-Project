namespace Business
{
    public class SearchResultPage : BasePage
    {
        protected readonly By PricingCalculator = By.CssSelector("a.gs-title[href*='cloud.google.com/products/calculator']");
        protected readonly By ListOfSearch = By.CssSelector(".gsc-expansionArea .gsc-webResult");
        protected readonly By ResultNegativeSearch = By.ClassName("gs-snippet");
        protected readonly By ResultEmptySearch = By.CssSelector(".devsite-article-body p");

        public SearchResultPage(DriverActions driverAction) : base(driverAction)
        {
        }

        public WelcomePricingCalculatorPage ClickPricingCalculatorLink()
        {
            driverAction.FindElementWithWaiterAndClick(PricingCalculator);
            return new WelcomePricingCalculatorPage(driverAction);
        }

        public IEnumerable<IWebElement> GetListOfSearch()
        {
            return driverAction.FindElementsWithWaiter(ListOfSearch);
        }

        public string GetTextNegativeSearch() 
        {
            return driverAction.FindElementWithWaiterAndGetText(ResultNegativeSearch);
        }

        public string GetTextEmptySearch()
        {
            return driverAction.FindElementWithWaiterAndGetText(ResultEmptySearch);
        }
    }
}