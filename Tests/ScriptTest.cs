using NUnit.Framework;

namespace LowCode.Tests
{
    [TestFixture, Order(4)]
    class ScriptTest : BaseClass
    {

        [SetUp]
        public void LauchingBrowserAndURL()
        {
            LaunchTheBrowser("Chrome");
            LaunchUserURL();
        }

        [Test, Order(1)]
        #region Add, Edit & Delete Script
        public void Script()
        {
            ManagerClass m = new(driver);
            m.Script.LoginAsUser();
            m.Script.AddScript();
            m.Script.EditScript();
            m.Script.DeleteScript();
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
