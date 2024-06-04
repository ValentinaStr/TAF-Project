using Core.DriverImplementation;
using OpenQA.Selenium;

namespace Business
{
    public class ComputeEnginePage : BasePage
    {
        #region locators
        private readonly By InstancesField = By.CssSelector("div[jsaction='JIbuQc:qGgAE'] button");
        private readonly By MachineTypeField = By.CssSelector("div[jsname=kgDJk]");
        private readonly By ChooseMachineType = By.CssSelector("ul.VfPpkd-rymPhb");
        private readonly By SelectAddGPUs = By.CssSelector("[aria-label='Add GPUs']");
        private readonly By ClickGPUType = By.CssSelector("[data-field-type='158'] .VfPpkd-aPP78e");
        private readonly By ChooseGPUType = By.CssSelector("[aria-label='Add GPUs']");
        private readonly By ClickLocalSSD = By.CssSelector("[data-field-type='180']");
        private readonly By ChooseLocalSSD = By.CssSelector("[aria-label='Local SSD']");
        private readonly By ChooseCommitedUsage = By.CssSelector("label.zT2df[for='1-year']");
        private readonly By Share = By.CssSelector("span.FOBRw-vQzf8d[jsname='V67aGc']");
        private readonly By OpenEstimate = By.CssSelector("a.tltOzc.MExMre.rP2xkc.jl2ntd[track-name='open estimate summary']");
        private readonly By Cost = By.CssSelector("label.gt0C8e.MyvX5d.D0aEmf");
        #endregion

        public ComputeEnginePage(DriverActions driverAction) : base(driverAction)
        {
        }

        public void ClickNumberOfInstances(int count)
        {
            for (int i = 1; i < count; i++)
            {
                driverAction.FindElementWithWaiterAndClick(InstancesField);
            }
        }

        public void PerformCalculation(string machineType, string gpuType, string localSSD)
        {
            driverAction.ScrollDown();
            DriverManager.HideCookieNotification();
            driverAction.FindElementWithWaiterAndClick(MachineTypeField);
            driverAction.SelectValueInDropdown(ChooseMachineType, machineType);
            driverAction.ScrollDown();
            DriverManager.HideCookieNotification();
            driverAction.FindElementWithWaiterAndClick(SelectAddGPUs);
            driverAction.FindElementWithWaiterAndClick(ClickGPUType);
            DriverManager.SelectValueInDropdown(ChooseGPUType, gpuType);
            driverAction.FindElementWithWaiterAndClick(ClickLocalSSD);
            DriverManager.SelectInDropdown(ChooseLocalSSD, localSSD);
            driverAction.FindElementWithWaiterAndClick(ChooseCommitedUsage);
        }


        public void ClickShare()
        {
            DriverManager.HideCookieNotification();
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
