using LowCode.PageObjects.Locators;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace LowCode.PageObjects
{
    class WebsitesPage : BaseClass
    {
        public IWebDriver driver;

        #region WebElements

        [FindsBy(How = How.XPath, Using = LoginPageLocator.emailField)]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocator.passwordField)]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocator.signInButton)]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.XPath, Using = WebsitesPageLocator.websitesTab)]
        public IWebElement websitesTab { get; set; }

        [FindsBy(How = How.XPath, Using = WebsitesPageLocator.editWebsiteNameIcon)]
        public IWebElement editWebsiteNameIcon { get; set; }

        [FindsBy(How = How.XPath, Using = WebsitesPageLocator.websiteNameField)]
        public IWebElement websiteNameField { get; set; }

        [FindsBy(How = How.XPath, Using = WebsitesPageLocator.saveIcon)]
        public IWebElement saveIcon { get; set; }

        [FindsBy(How = How.XPath, Using = WebsitesPageLocator.deleteWebsiteIcon)]
        public IWebElement deleteWebsiteIcon { get; set; }

        [FindsBy(How = How.XPath, Using = WebsitesPageLocator.deleteButton)]
        public IWebElement deleteButton { get; set; }
        #endregion

        #region Constructor
        public WebsitesPage(IWebDriver driver)
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

        #region EditWebsiteName
        public void EditWebsiteName()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement websitesTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='lc-homepage-selection']/div[@routerlink='/websites']")));
            websitesTab.Click();

            IWebElement websiteName = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html[1]/body[1]/app-root[1]/app-main[1]/div[1]/section[1]/section[1]/app-projects[1]/div[1]/div[2]/div[1]/div[2]/div[2]/span[1]")));
            Actions action = new Actions(driver);
            action.MoveToElement(websiteName).Perform();
            IWebElement editWebsiteIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html[1]/body[1]/app-root[1]/app-main[1]/div[1]/section[1]/section[1]/app-projects[1]/div[1]/div[2]/div[1]/div[2]/div[2]/a[1]/i[1]")));
            editWebsiteIcon.Click();
            websiteNameField.Clear();
            websiteNameField.SendKeys("Livspace Interiors");
            saveIcon.Click();  

            //IWebElement addBusinessEntitySuccessMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Business Added successfully!')]")));
            //Assert.IsTrue(editWebsiteNameSuccessMessage.Text.Contains("Website details updated successfully!"),"Expected success message was not displayed.");
        }
        #endregion

        #region DeleteWebsite
        public void DeleteWebsite()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement deleteWebsiteIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='mat-mdc-tooltip-trigger ellipsis-rotate']/a")));
            deleteWebsiteIcon.Click();

            deleteButton.Click();

            //IWebElement addBusinessEntitySuccessMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Business Added successfully!')]")));
            //Assert.IsTrue(editWebsiteNameSuccessMessage.Text.Contains("Project deleted successfully!"),"Expected success message was not displayed.");
        }
        #endregion
    }
}
