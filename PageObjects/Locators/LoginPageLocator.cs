
namespace LowCode.PageObjects.Locators
{
    class LoginPageLocator
    {
        #region LoginPage
        public const string emailField = "//input[@id='login-username']";
        public const string passwordField = "//input[@id='login-password']";
        public const string signInButton = "//button[contains(text(),'Sign In')]";
        #endregion

        #region HomePage
        public const string countrySelectionDropdownField = "//div[@class='field-wrapper']//div[@class='ng-select-container ng-has-value']";
        public const string listOfCountries = "//div[@class='ng-dropdown-panel-items scroll-host']//div";
        public const string continueButton = "//button[contains(text(),'Continue')]";
        public const string profileIcon = "//button[@id='dropdownBasic1']";
        public const string signOut = "//button[@class='dropdown-item'][4]";
        #endregion
    }
}
