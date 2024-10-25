using NUnit.Framework;

namespace LowCode.Tests
{
    [TestFixture, Order(1)]
    class LoginTest : BaseClass
    {

        [SetUp]
        public void LauchingBrowserAndURL()
        {
            LaunchTheBrowser("Chrome");
            LaunchUserURL();
        }

        [Test, Order(1)]
        #region Login to Free User Account
        public void LoginAsFreeUser()
        {
            ManagerClass m = new(driver);
            m.Login.LoginAsFreeUser();
        }
        #endregion

        [Test, Order(2)]
        #region Login to Pro User Account
        public void LoginAsProUser()
        {
            ManagerClass m = new(driver);
            m.Login.LoginAsProUser();
        }
        #endregion


        [TearDown]
        public void ClosingBrowser()
        {
            driver.Dispose();
            driver.Quit();
        }
    }

}
