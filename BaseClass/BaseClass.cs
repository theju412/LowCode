using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace LowCode

{
    public class BaseClass
    {

        public static IWebDriver driver;
        public IWebDriver getDriver()
        {
            return driver;
        }
        public static void LaunchTheBrowser(string browser)
        {
            if (browser == "Chrome")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }
            else if (browser == "Firefox")
            {
                driver = new FirefoxDriver();
            }
            else if (browser == "Edge")
            {
                driver = new EdgeDriver();
            }
        }
        public static void LaunchUserURL()
        {
            driver.Url = "https://lemon-cliff-0d5987100.5.azurestaticapps.net/auth/login";
            driver.Manage().Window.Maximize();
        }
        public static void InputValue(IWebElement a, string b)
        {
            a.SendKeys(b);
        }
        public static void ClickOnElement(IWebElement c)
        {
            c.Click();
        }
        public static void TakeScreenshot()
        {
            ITakesScreenshot se = (ITakesScreenshot)driver;
            Screenshot screenshot = se.GetScreenshot();
            screenshot.SaveAsFile("D:\\Automation\\NimblePlan\\NimblePlan\\Images\\Image.png");

        }
        public static void ImplicitWait(IWebElement x)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            x.Click();
            driver.Quit();
        }
        public static void ExplicitWait(string y)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(y)));
        }
        public static void Action(IWebElement at)
        {
            Actions a = new(driver);

            a.Click(at).Perform();
            a.ContextClick(at).Perform();
            a.SendKeys(Keys.Tab).Perform();
            a.SendKeys(Keys.PageDown).Perform();
        }
        public static void AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
        public static void DismissAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        //public void CloseBrowser(ExtentReports extent)
        //{
        //    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        //    {

        //        var testName = TestContext.CurrentContext.Test.Name;
        //        string filename = testName;

        //        var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "<pre>";
        //        var errorMessage = TestContext.CurrentContext.Result.Message;

        //        test.Log(LogStatus.Fail, testName + "  is Failed ");
        //        test.Log(LogStatus.Info, errorMessage);
        //        test.Log(LogStatus.Info, stackTrace);
        //    }

        //    extent.EndTest(test);
        //    extent.Flush();
        //    driver.Quit();

        //}
    }
}