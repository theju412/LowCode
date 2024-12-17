namespace LowCode.PageObjects.Locators
{
    class WebsitesPageLocator
    {
        #region WebsitesPage
        public const string websitesTab = "//div[@class='lc-homepage-selection']/div[@routerlink='/websites']";
        public const string websiteName = "/html[1]/body[1]/app-root[1]/app-main[1]/div[1]/section[1]/section[1]/app-projects[1]/div[1]/div[2]/div[1]/div[2]/div[2]/span[1]";
        public const string editWebsiteNameIcon = "/html[1]/body[1]/app-root[1]/app-main[1]/div[1]/section[1]/section[1]/app-projects[1]/div[1]/div[2]/div[1]/div[2]/div[2]/a[1]/i[1]";
        public const string websiteNameField = "//input[@placeholder='Business Name']";
        public const string saveIcon = "//div[@class='pne-action-btn']/button[1]";

        public const string deleteWebsiteIcon = "//div[@class='mat-mdc-tooltip-trigger ellipsis-rotate']/a";
        public const string deleteButton = "//button[contains(text(),'Delete')]";
        #endregion
    }
} 