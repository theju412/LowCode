using LowCode.PageObjects.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace LowCode.PageObjects
{
    class LoginPage : BaseClass
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

        [FindsBy(How = How.XPath, Using = LoginPageLocator.signOut)]
        public IWebElement signOut { get; set; }

        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        #endregion

        #region LoginToFreeUserAccount
        public void LoginAsFreeUser()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement emailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-username")));
          
            emailField.SendKeys("dhanya@yopmail.com");
            passwordField.SendKeys("Test@123");
            signInButton.Click();

            IWebElement profileIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("dropdownBasic1")));
            profileIcon.Click();
            signOut.Click();
        }
        #endregion

        #region LoginToProUserAccount
        public void LoginAsProUser()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement emailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-username")));

            emailField.SendKeys("shilpa@yopmail.com");
            passwordField.SendKeys("Test@123");
            signInButton.Click();

            IWebElement profileIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("dropdownBasic1")));
            profileIcon.Click();
            signOut.Click();
        }
        #endregion

    }

}
