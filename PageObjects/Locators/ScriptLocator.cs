
namespace LowCode.PageObjects.Locators
{
    class ScriptLocator
    {
        #region Add Script
        public const string websitesTab = "(//div[@class='selection-box'])[1]";
        public const string editWebsiteButton = "//button[contains(text(),'Edit')]";

        public const string advancedEditWebsiteIcon = "//button[@class='action-button chatbot-edit-container']";
        public const string editScriptIcon = "(//a[@class='mat-mdc-tooltip-trigger edit-icon'])[2]";
        public const string scriptField = "(//textarea[@formcontrolname='scriptText'])";
        public const string addScriptButton = "//button[contains(text(),'Add')]";
        public const string updateScriptIcon = "(//button[@class='edit-icon me-1 ng-star-inserted'])[1]";
        public const string deleteScriptIcon = "(//button[@class='edit-icon ng-star-inserted'])[1]";
        public const string editScriptField = "(//textarea[@formcontrolname='scriptText'])[2]";
        public const string saveScriptIcon = "(//button[@class='update-icon'])[1]";
        #endregion
    }
}
