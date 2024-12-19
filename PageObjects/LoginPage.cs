using Spaidy.PageObjects.Locators;
using Spaidy.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using Spaidy.BaseSetUp;

namespace Spaidy.PageObjects
{
    class LoginPage : BaseSetUpClass
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

        #region SignInToFreeUserAccount And SignOut

        #region Passing UserName
        public void SetUserNameForFreeAccount(string freeAccountUserName)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement emailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-username")));
            Assert.IsTrue(emailField.Displayed);

            emailField.EnterValue(freeAccountUserName);
        }
        #endregion

        #region Passing password
        public void SetPasswordForFreeAccount(string freeAccountPassword)
        {
            Assert.IsTrue(passwordField.Displayed);
            passwordField.EnterValue(freeAccountPassword);
        }
        #endregion

        #region Clicking on Sign In button
        public void ClickSignInButtonForFreeAccount()
        {

            Assert.IsTrue(signInButton.Displayed);
            signInButton.Click();
        }
        #endregion

        #region Clicking on Sign Out button
        public void ClickSignOutButtonForFreeAccount()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement profileIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("dropdownBasic1")));
            Assert.IsTrue(profileIcon.Displayed);

            profileIcon.Click();
            signOut.Click();
        }
        #endregion

        #endregion

    }

}

