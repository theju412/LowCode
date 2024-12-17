using LowCode.PageObjects.Locators;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace LowCode.PageObjects
{
    class Script : BaseClass
    {
        public IWebDriver driver;

        #region WebElements
        [FindsBy(How = How.XPath, Using = LoginPageLocator.emailField)]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocator.passwordField)]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocator.signInButton)]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.websitesTab)]
        public IWebElement websitesTab { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.editWebsiteButton)]
        public IWebElement editWebsiteButton { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.advancedEditWebsiteIcon)]
        public IWebElement advancedEditWebsiteIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.editScriptIcon)]
        public IWebElement editScriptIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.scriptField)]
        public IWebElement scriptField { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.addScriptButton)]
        public IWebElement addScriptButton { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.updateScriptIcon)]
        public IWebElement updateScriptIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.deleteScriptIcon)]
        public IWebElement deleteScriptIcon { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.editScriptField)]
        public IWebElement editScriptField { get; set; }

        [FindsBy(How = How.XPath, Using = ScriptLocator.saveScriptIcon)]
        public IWebElement saveScriptIcon { get; set; }
        #endregion

        #region Constructor
        public Script(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        #endregion

        #region LoginToUserAccount
        public void LoginAsUser()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement emailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-username")));

            emailField.SendKeys("shilpa@yopmail.com");
            passwordField.SendKeys("Test@123");
            signInButton.Click();
        }
        #endregion

        #region Add Script
        public void AddScript()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement websitesTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='selection-box'])[1]")));
            websitesTab.Click();

            IWebElement editWebsiteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Edit')]")));
            editWebsiteButton.Click();

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader-spinner")));
            IWebElement advancedEditWebsiteIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='action-button chatbot-edit-container']")));
            advancedEditWebsiteIcon.Click();
            IWebElement editScriptIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@class='mat-mdc-tooltip-trigger edit-icon'])[2]")));
            editScriptIcon.Click();

            scriptField.SendKeys("<script> This is a test script! </script>");
            addScriptButton.Click();
        }
        #endregion

        #region Edit Script
        public void EditScript()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement updateScriptIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@class='edit-icon me-1 ng-star-inserted'])[1]")));
            updateScriptIcon.Click();

            IWebElement editScriptField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//textarea[@formcontrolname='scriptText'])[2]")));
            editScriptField.Clear();
            editScriptField.SendKeys("<script> This is updated script! </script>");
            saveScriptIcon.Click();
        }
        #endregion

        #region Delete Script
        public void DeleteScript()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement deleteScripticon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@class='edit-icon ng-star-inserted'])[1]")));
            deleteScripticon.Click();
        }
        #endregion
    }
}
