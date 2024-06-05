namespace Business
{
    public class WelcomePricingCalculatorPage : BasePage
    {
        protected readonly By AddToEstimateButton = By.CssSelector("span.UywwFc-vQzf8d[jsname='V67aGc']");
        protected readonly By ComputeEngineItem = By.CssSelector("div[data-service-form='8']");

        public WelcomePricingCalculatorPage(DriverActions driverAction) : base(driverAction)
        {
        }

        public void ClickAddToEstimateButton()
        {
            driverAction.FindElementWithWaiterAndClick(AddToEstimateButton);
        }

        public ComputeEnginePage ClickComputeEngineItem()
        {
            driverAction.FindElementWithWaiterAndClick(ComputeEngineItem);
            return new ComputeEnginePage(driverAction);
        }
    }
}
