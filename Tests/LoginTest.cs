using Spaidy.DataReader;
using Spaidy.PageObjects;
using NUnit.Framework;
using Spaidy.BaseSetUp;

namespace Spaidy.Tests
{
    [TestFixture, Order(1)]
    class LoginTest : BaseSetUpClass
    {

        [SetUp]
        public void LauchingBrowserAndURL()
        {
            
            driver = LaunchingTheBrowserAndOpeningLowCodeURL();
        }

        [Test]   
        #region Login to Free User Account
        public void LoginAsFreeUser()
        {

            string UserNameValue = ExcelReaderHelper.GetCellData(fileLocation, "ValidCredentials", 1, 3).ToString();
            string PasswordValue = ExcelReaderHelper.GetCellData(fileLocation, "ValidCredentials", 2, 3).ToString();

            LoginPage loginObj = new LoginPage(driver);
            loginObj.SetUserNameForFreeAccount(UserNameValue);
            loginObj.SetPasswordForFreeAccount(PasswordValue);
            loginObj.ClickSignInButtonForFreeAccount();
            loginObj.ClickSignOutButtonForFreeAccount();

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

