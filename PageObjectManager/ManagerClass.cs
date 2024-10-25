using LowCode.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LowCode
{
    class ManagerClass
    {

        public IWebDriver driver;
        public LoginPage Login => new LoginPage(driver);
        public ManagerClass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}