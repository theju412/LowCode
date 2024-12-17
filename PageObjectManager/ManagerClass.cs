using LowCode.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LowCode
{
    class ManagerClass
    {

        public IWebDriver driver;
        public LoginPage Login => new LoginPage(driver);
        public BusinessSettings BusinessSettings => new BusinessSettings(driver);
        public WebsitesPage WebsitesPage => new WebsitesPage(driver);
        public Script Script => new Script(driver);
        public ManagerClass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}