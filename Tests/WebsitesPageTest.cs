using NUnit.Framework;

namespace LowCode.Tests
{
    [TestFixture, Order(3)]
    class WebsitesPageTest : BaseClass
    {

        [SetUp]
        public void LauchingBrowserAndURL()
        {
            LaunchTheBrowser("Chrome");
            LaunchUserURL();
        }

        [Test]
        #region Edit & Delete Website
        public void WebsitesPage()
        {
            ManagerClass m = new(driver);
            m.WebsitesPage.LoginAsUser();
            m.WebsitesPage.EditWebsiteName();
            m.WebsitesPage.DeleteWebsite();
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
