using LowCode.PageObjects.Locators;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace LowCode.PageObjects
{
    class BusinessSettings : BaseClass
    {
        public IWebDriver driver;

        #region WebElements

        [FindsBy(How = How.XPath, Using = LoginPageLocator.emailField)]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocator.passwordField)]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocator.signInButton)]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocator.profileIcon)]
        public IWebElement profileIcon { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.businessSettings)]
        public IWebElement businessSettings { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.addNewBusinessEntityButton)]
        public IWebElement addNewBusinessEntityButton { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.businessNameField)]
        public IWebElement businessNameField { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.businessEntityEmailField)]
        public IWebElement businessEntityEmailField { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.businessEntityPhoneField)]
        public IWebElement businessEntityPhoneField { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.businessEntityAddressField)]
        public IWebElement businessEntityAddressField { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.businessEntityTaxPercentField)]
        public IWebElement businessEntityTaxPercentField { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.addButton)]
        public IWebElement addButton { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.addBusinessEntitySuccessMessage)]
        public IWebElement addBusinessEntitySuccessMessage { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.editBusinessEntityIcon)]
        public IWebElement editBusinessEntityIcon { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.UpdateBusinessEntityPhoneField)]
        public IWebElement UpdateBusinessEntityPhoneField { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.updateButton)]
        public IWebElement updateButton { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.updateBusinessEntitysuccessMessage)]
        public IWebElement updateBusinessEntitysuccessMessage { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.deleteBusinessEntityIcon)]
        public IWebElement deleteBusinessEntityIcon { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.yesButton)]
        public IWebElement yesButton { get; set; }

        [FindsBy(How = How.XPath, Using = BusinessSettingsLocator.deleteBusinessEntitySuccessMessage)]
        public IWebElement deleteBusinessEntitySuccessMessage { get; set; }
        #endregion

        #region Constructor
        public BusinessSettings(IWebDriver driver)
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

        #region AddBusinessEntity
        public void AddBusinessEntity()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement profileIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("dropdownBasic1")));
            profileIcon.Click();
            businessSettings.Click();

            IWebElement addNewBusinessEntityButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='add-reminder-link']")));
            addNewBusinessEntityButton.Click();
            businessNameField.SendKeys("Livspace Interiors");
            businessEntityEmailField.SendKeys("livspace@yopmail.com");

            IWebElement businessEntityPhoneField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='mat-input-0']")));
            businessEntityPhoneField.SendKeys("9999999999");

            businessEntityAddressField.SendKeys("#149, 6th sector");
            businessEntityTaxPercentField.Clear();
            businessEntityTaxPercentField.SendKeys("12");
            addButton.Click();

            //IWebElement addBusinessEntitySuccessMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Business Added successfully!')]")));
            //Assert.IsTrue(addBusinessEntitySuccessMessage.Text.Contains("Business added successfully!"),"Expected success message was not displayed.");
        }
        #endregion

        #region UpdateBusinessEntity
        public void UpdateBusinessEntity()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement editBusinessEntityIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html[1]/body[1]/app-root[1]/app-main[1]/div[1]/section[1]/app-header[1]/app-business-settings[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/a[1]")));
            editBusinessEntityIcon.Click();

            businessNameField.Clear();
            businessNameField.SendKeys("Livspace Designs");
            businessEntityEmailField.Clear();
            businessEntityEmailField.SendKeys("livspacedesigns@yopmail.com");

            UpdateBusinessEntityPhoneField.Clear();
            IWebElement businessEntityPhone = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='mat-input-1']")));
            UpdateBusinessEntityPhoneField.SendKeys("8888888888");

            businessEntityAddressField.Clear();
            businessEntityAddressField.SendKeys("#172, 14th sector");
            businessEntityTaxPercentField.Clear();
            businessEntityTaxPercentField.SendKeys("7");

            IWebElement updateButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Update')]")));
            updateButton.Click();

            //IWebElement updateBusinessEntitysuccessMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Business Updated successfully!')]")));
            //Assert.IsTrue(updateBusinessEntitysuccessMessage.Text.Contains("Business updated successfully!"), "Expected success message was not displayed.");
        }
        #endregion

        #region DeleteBusinessEntity
        public void DeleteBusinessEntity()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));            

            IWebElement deleteBusinessEntityIcon = driver.FindElement(By.XPath("(//a[@class='delete-icon'])[1]"));
            try
            {
                deleteBusinessEntityIcon.Click(); 
            }
            catch (StaleElementReferenceException)
            {
                deleteBusinessEntityIcon = driver.FindElement(By.XPath("(//a[@class='delete-icon'])[1]"));
                deleteBusinessEntityIcon.Click();
            }

            IWebElement yesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes')]")));
            yesButton.Click();

            //IWebElement deleteBusinessEntitysuccessMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Business Deleted successfully')]")));
            //Assert.IsTrue(deleteBusinessEntitysuccessMessage.Text.Contains("Business deleted successfully!"), "Expected success message was not displayed.");
        }
        #endregion
    }
}