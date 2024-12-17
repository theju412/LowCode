using NUnit.Framework;

namespace LowCode.Tests
{
    [TestFixture, Order(2)]
    class BusinessSettingsTest : BaseClass
    {

        [SetUp]
        public void LauchingBrowserAndURL()
        {
            LaunchTheBrowser("Chrome");
            LaunchUserURL();
        }

        [Test, Order(1)]
        #region Add Update & Delete BusinessEntity
        public void BusinessEntity()
        {
            ManagerClass m = new(driver);
            m.BusinessSettings.LoginAsUser();
            m.BusinessSettings.AddBusinessEntity();
            m.BusinessSettings.UpdateBusinessEntity();
            m.BusinessSettings.DeleteBusinessEntity();
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
