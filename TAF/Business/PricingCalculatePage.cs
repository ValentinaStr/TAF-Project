namespace Business
{
    public class PricingCalculatorPage : BasePage
    {
        #region locators
        private readonly By GPUTypeField = By.XPath("//md-select[@ng-model='listingCtrl.computeServer.gpuType']");
        private readonly By LocalSSDField = By.XPath("//md-select[@ng-model='listingCtrl.computeServer.localSsd']");
        private readonly By CommitedUsageField = By.XPath("//md-select[@ng-model='listingCtrl.computeServer.commitmentTerm']");
        private readonly By ShareField = By.XPath("//form[@name='emailForm']");
        private readonly By OpenEstimateField = By.XPath("//button[@ng-click='listingCtrl.openEmailForm()']");
        private readonly By CostLocator = By.XPath("//div[@class='md-list-item-text ng-binding']");
        #endregion
        public PricingCalculatorPage(DriverActions driverAction) : base(driverAction)
        {
        }

        public void ClickChooseGPUType()
        {
            driverAction.FindElementWithWaiterAndClick(GPUTypeField);
        }

        public void AddGPUType()
        {
            driverAction.FindElementWithWaiterAndClick(GPUTypeField);
        }

        public void ClickChooseLocalSSD()
        {
            driverAction.FindElementWithWaiterAndClick(LocalSSDField);
        }

        public void AddLocalSSD()
        {
            driverAction.FindElementWithWaiterAndClick(LocalSSDField);
        }

        public void ClickCommitedUsage()
        {
            driverAction.FindElementWithWaiterAndClick(CommitedUsageField);
        }

        public void ClickShare()
        {
            driverAction.FindElementWithWaiterAndClick(ShareField);
        }

        public void ClickOpenEstimate()
        {
            driverAction.FindElementWithWaiterAndClick(OpenEstimateField);
        }

        public string GetCost()
        {
            return driverAction.FindElementWithWaiterAndGetText(CostLocator);
        }

        public EstimateSummaryPage ReturnToEstimate()
        {
            ClickOpenEstimate();
            return new EstimateSummaryPage(driverAction);
        }
    }
}

