namespace Business
{
    public class HomePage : BasePage
    {
        private readonly By SearchField = By.CssSelector("input.mb2a7b");

        public HomePage(DriverActions driverActions) : base(driverActions)
        {
            driverAction.GoToUrl(TestRunSettings.Instance.Url);
        }

        public void AddTextToSearchField(string text)
        {
            driverAction.FindElementWithWaiterAndEnterText(SearchField, text);
        }

        public SearchResultPage OpenSurchResult()
        {
            driverAction.ClickEnter(SearchField);
            return new SearchResultPage(driverAction);
        }
    }
}
