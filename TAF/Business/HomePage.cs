namespace Business
{
    public class HomePage : BasePage
    {
        #region locators
        private readonly By SearchField = By.CssSelector("input.mb2a7b");
        private readonly By LanguageSelector = By.CssSelector("[track-type='languageSelector']");
        private readonly By MenuHeader = By.Id("kO001e");
        #endregion

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

        public string GetNavigationMenuHeaderText()
        {
            return driverAction.FindElementWithWaiterAndGetText(MenuHeader);
        }

        public void ChangeLanguage(string languageCode)
        {
            driverAction.FindElementWithWaiterAndClick(LanguageSelector);
            driverAction.FindElementWithWaiterAndClick(By.CssSelector($"[data-value='{languageCode}']"));
        }
    }
}
