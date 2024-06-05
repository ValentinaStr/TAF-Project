namespace Business
{
    public class BasePage
    {
        protected DriverActions driverAction {  get; set; }
        protected BasePage(DriverActions driverAction)
        {
            this.driverAction = driverAction;
        }

        public bool CheckPresenceWordOnThePage(string keyword)
        {
            return driverAction.CheckPresenceWordOnThePage(keyword);
        }

        public void WaitForFileDownload(string defaultDownloadDirectory, string filename)
        {
            driverAction.WaitForFileDownload(defaultDownloadDirectory, filename);
        }
    }
}