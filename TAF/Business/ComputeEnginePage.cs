namespace Business
{
    public class ComputeEnginePage : BasePage
    {
        #region locators
        private readonly By InstancesField = By.CssSelector("div[jsaction='JIbuQc:qGgAE'] button");
        private readonly By MachineTypeField = By.CssSelector("div[jsname=kgDJk");
        private readonly By ChooseMachineType = By.CssSelector("ul.VfPpkd-rymPhb");
        private readonly By AddGPUs = By.CssSelector("[aria-label='Add GPUs']");
        private readonly By ClickGPUType = By.CssSelector("[data-field-type='158'] .VfPpkd-aPP78e");
        private readonly By ChooseGPUType = By.CssSelector("[aria-label='Add GPUs']");
        private readonly By AddLocalSSD = By.CssSelector("[data-field-type='180']");
        private readonly By ChooseLocalSSD = By.CssSelector("[aria-label='Local SSD']");
        private readonly By DownloadEstimate = By.CssSelector("[aria-label='Download estimate as .csv']");
        private readonly By Share = By.CssSelector("span.FOBRw-vQzf8d[jsname='V67aGc']");
        private readonly By OpenEstimate = By.CssSelector("a.tltOzc.MExMre.rP2xkc.jl2ntd[track-name='open estimate summary']");
        private readonly By Cost = By.CssSelector("label.gt0C8e.MyvX5d.D0aEmf");
        #endregion

        public ComputeEnginePage(DriverActions driverAction) : base(driverAction)
        {
        }

        public void AddNumberOfInstances(int count)
        {
            driverAction.ScrollToElement(InstancesField);
            for (int i = 1; i < count; i++)
            {
                driverAction.FindElementWithWaiterAndClick(InstancesField);
            }
        }

        public void SelectMachineType(string machineType)
        {
            driverAction.ScrollDown();
            driverAction.HideCookieNotification();
            driverAction.FindElementWithWaiterAndClick(MachineTypeField);
            driverAction.SelectValueInDropdownByXPath(ChooseMachineType, machineType);
        }

        public void SelectAddGPUs()
        {
            driverAction.ScrollDown();
            driverAction.FindElementWithWaiterAndClick(AddGPUs);
        }

        public void AddGPUsType(string gpuType)
        {
            SelectAddGPUs();
            driverAction.FindElementWithWaiterAndClick(ClickGPUType);
            driverAction.SelectValueInDropdownByXPath(ChooseGPUType, gpuType);
        }

        public void ChooseAddLocalSSD(string localSSD)
        {
            driverAction.FindElementWithWaiterAndClick(AddLocalSSD);
            driverAction.ScrollDown();
            driverAction.SelectValueInDropdownByCssSelector(ChooseLocalSSD, localSSD);
        }

        public void DownloadEstimateCsv()
        {
            driverAction.FindElementWithWaiterAndClick(DownloadEstimate);
        }

        public void ClickShare()
        {
            // DriverManager.HideCookieNotification();
            driverAction.FindElementWithWaiterAndClick(Share);
        }

        public EstimateSummaryPage ClickOpenEstimate()
        {
            driverAction.FindElementWithWaiterAndClick(OpenEstimate);
            return new EstimateSummaryPage(driverAction);
        }

        public string GetCost()
        {
            driverAction.RefreshPage();
            return driverAction.FindElementWithWaiterAndGetText(Cost);
        }
    }
}
