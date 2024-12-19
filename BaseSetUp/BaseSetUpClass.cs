using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Spaidy.Utilities;
using Spaidy.DataReader;

namespace Spaidy.BaseSetUp
{
    public class BaseSetUpClass : TestBase
    {
        public string BrowserType { get; private set; }
        public string URL { get; private set; }

        public static BaseSetUpClass Create()
        {
            return new BaseSetUpClass();
        }

        public BaseSetUpClass()
        {
            BrowserType = ExcelReaderHelper.GetCellData(fileLocation, "BrowserName", 1, 0).ToString();
            URL = ExcelReaderHelper.GetCellData(fileLocation, "URL", 1, 1).ToString();

        }

        public IWebDriver LaunchingTheBrowserAndOpeningLowCodeURL()
        {

            switch (BrowserType)
            {
                case "Chrome":
                    ChromeOptions option = new ChromeOptions();
                    driver = new ChromeDriver(option);
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(URL);
                    break;

                //case "Firefox":
                //    FirefoxProfile profile = new FirefoxProfile();
                //    profile.SetPreference("browser.download.folderList", 2);
                //    profile.SetPreference("browser.download.dir", "C:\\Windows\\temp");
                //    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
                //    profile.SetPreference("pdfjs.disabled", true);
                //    profile.AcceptUntrustedCertificates = true;
                //    profile.SetPreference("security.insecure_password.ui.enabled", false);
                //    profile.SetPreference("security.insecure_field_warning.contextual.enabled", false);

                //    driver = new FirefoxDriver(profile);
                //    driver.Manage().Window.Maximize();
                //    driver.Navigate().GoToUrl(URL);
                //    break;

                case "IE":
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(URL);

                    break;
                default:
                    Console.WriteLine("Inavlid driver object Launching Firefox as browser of choice..");
                    break;

            }
            return driver;
        }


    }
}

