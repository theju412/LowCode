using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Spaidy.Utilities
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected readonly string fileLocation = ConfigurationManager.AppSettings["fileLocation"];

    }
}
