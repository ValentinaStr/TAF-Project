using Core.DriverImplementation;
using OpenQA.Selenium;

namespace Business
{
    public class EstimateSummaryPage : BasePage
    {
        protected readonly By CostEstimateSummaryLocator = By.CssSelector(".OtcLZb.OIcOye");

        public EstimateSummaryPage(DriverActions driverAction) : base(driverAction)
        {
        }

        public string GetCostEstimateSummary()
        {
            return driverAction.FindElementWithWaiterAndGetText(CostEstimateSummaryLocator);
        }
    }
}
