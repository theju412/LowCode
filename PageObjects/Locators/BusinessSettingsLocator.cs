

namespace LowCode.PageObjects.Locators
{
    class BusinessSettingsLocator
    {
        #region BusinessSettings
        public const string businessSettings = "//div[@class='user-dropdown dropdown-menu show']/button[3]";
        public const string addNewBusinessEntityButton = "//a[@class='add-reminder-link']";
        public const string businessNameField = "//input[@formcontrolname='name']";
        public const string businessEntityEmailField = "//input[@formcontrolname='email']";
        public const string businessEntityPhoneField = "//input[@id='mat-input-0']";
        public const string businessEntityAddressField = "//textarea[@formcontrolname='address']";
        public const string businessEntityTaxPercentField = "//input[@formcontrolname='taxPercentage']";
        public const string addButton = "//button[contains(text(),'Add')]";
        public const string addBusinessEntitySuccessMessage = "//div[contains(text(),'Business Added successfully!')]";
        public const string editBusinessEntityIcon = "/html[1]/body[1]/app-root[1]/app-main[1]/div[1]/section[1]/app-header[1]/app-business-settings[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/a[1]";
        public const string UpdateBusinessEntityPhoneField = "//input[@id='mat-input-1']";
        public const string updateButton = "//button[contains(text(),'Update')]";
        public const string updateBusinessEntitysuccessMessage = "//div[contains(text(),'Business Updated successfully!')]";
        public const string deleteBusinessEntityIcon = "(//a[@class='delete-icon'])[1]";
        public const string yesButton = "//button[contains(text(),'Yes')]";
        public const string deleteBusinessEntitySuccessMessage = "//div[contains(text(),'Business Deleted successfully')]";
        #endregion
    }
}
