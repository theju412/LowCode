using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Spaidy.Utilities
{
    public static class CustomMethods
    {
        // this keyword is used for extension method for c sharp which is more generic
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }


        //Enter text or any value in the Textbox or any fields       
        public static void EnterValue(this IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        //public static void ClearField(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        //    element.Click();
        //    element.Clear();
        //}

        ////enter value through waiting the element
        //public static void EnterValue(this IWebElement element, IWebDriver driver, string locator, string dataToEnter, int timeInSeconds)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        //    element.Click();
        //    element.Clear();
        //    element.SendKeys(dataToEnter);
        //}


        //Click into a button
        public static void ClickOnButton(this IWebElement element)
        {
            element.Click();
        }

        #region Click On Function with Dynamic Wait
        //click on button using wait        
        public static void ClickOn(this IWebElement element, IWebDriver driver, int timeInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }
        //function overloading with locator parameter
        public static void ClickOn(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
            element.Click();
        }

        //Overloading with driver extension
        public static void ClickOn(this IWebDriver driver, IWebElement element, int timeInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }

        public static void ClickOn(this IWebDriver driver, IWebElement element, string locator, int timeInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
            element.Click();
        }

        #endregion





        //click on links
        public static void ClickOnLink(this IWebElement element)
        {
            element.Click();
        }

        //Selecting a drop down control
        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static string GetSelectedTextValue(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            String text = select.SelectedOption.Text;
            return text;
        }

        public static void GoToURL(this IWebDriver driver, string value)
        {
            driver.Url = value;
        }

        //close driver
        public static void CloseDriver(this IWebDriver driver)
        {
            driver.Close();
        }

        //checkbox
        public static void SelectCheckbox(this IWebElement element)
        {
            if (element.Displayed || element.Enabled)
            {
                element.Click();
            }

        }

        public static void DeselectCheckbox(this IWebElement element)
        {
            if (!(element.Displayed || element.Enabled))
            {
                element.Click();
            }

        }
        //radioButton
        public static void ClickOnRadiobutton(this IWebElement element)
        {
            if (element.Displayed || element.Enabled)
            {
                element.Click();
            }

        }

        public static Boolean IsElementDisplayed(this IWebDriver driver, string locator, int timeInSeconds)
        {
            driver.WaitForElementIfPresent(timeInSeconds);
            if (driver.FindElements(By.XPath(locator)).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //select a text from dropdown
        public static IWebElement SelectTextFromDropDown(this IWebDriver driver, string xpath, string textValue)
        {
            IList<IWebElement> list = driver.FindElements(By.XPath(xpath));
            int i;
            for (i = 1; i < list.Count; i++)
            {

                if (list[i].Text.Equals(textValue))
                {
                    //return list[i];
                    list = driver.FindElements(By.XPath(xpath));
                    break;
                }


            }
            //list[i].Click();
            //list = driver.FindElements(By.XPath(xpath));
            return list[i];

        }

        //Using pagination Return List<IWebElement>

        public static List<IWebElement> SelectNextPageAndReturnListOfWebElement(IList<IWebElement> xpathOfList, IWebElement NextArrow, IList<IWebElement> NumberOfPage)
        {
            List<IWebElement> list1 = new List<IWebElement>();
            for (int i = 0; i < NumberOfPage.Count; i++)
            {
                if (i == 0 || i == NumberOfPage.Count - 1)
                {
                    continue;
                }
                else
                {
                    Thread.Sleep(3000);
                    foreach (IWebElement element in xpathOfList)
                    {
                        list1.Add(element);

                        //Console.WriteLine("All element's " + username.Text);
                    }

                    NextArrow.Click();
                }
            }
            return list1;


        }
        // Each Page wise Number of Record Display
        public static List<string> NumberOfRecord(IWebElement xpathOfREcord, IWebElement NextArrow, IList<IWebElement> NumberOfPage)
        {
            List<string> list1 = new List<string>();
            for (int i = 0; i < NumberOfPage.Count; i++)
            {
                if (i == 0 || i == NumberOfPage.Count - 1)
                {
                    continue;
                }
                else
                {
                    //  foreach (IWebElement element in xpathOfREcord)
                    //  {
                    list1.Add(xpathOfREcord.Text);
                    //   }

                    NextArrow.Click();
                }
            }
            return list1;
        }

        //Using pagination Return List<string>

        public static List<string> SelectNextPage(IList<IWebElement> xpathOfList, IWebElement NextArrow, IList<IWebElement> NumberOfPage)
        {
            List<string> list1 = new List<string>();
            for (int i = 0; i < NumberOfPage.Count; i++)
            {
                if (i == 0 || i == NumberOfPage.Count - 1)
                {
                    continue;
                }
                else
                {
                    foreach (IWebElement element in xpathOfList)
                    {
                        list1.Add(element.Text);
                    }

                    NextArrow.Click();
                }
            }
            return list1;


        }

        //For Clicking 1st Page in Pagination

        public static void ClickOnFirstPage(IWebElement firstPage)
        {
            firstPage.Click();
            // Thread.Sleep(3000);
            // Thread.Sleep(1000);
        }

        public static IList<IWebElement> GetAllTheListValue(this IWebDriver driver, string xpathOfList)
        {
            //var test = TakeScreenShot.extent.StartTest("Read Values from List");

            IList<IWebElement> list = driver.FindElements(By.XPath(xpathOfList));
            //int i;
            for (int i = 0; i < list.Count; i++)
            {
                list = driver.FindElements(By.XPath(xpathOfList));
                //test.Log(LogStatus.Info, list[i].Text);
            }
            return list;

            //TakeScreenShot.extent.EndTest(test);
            //TakeScreenShot.extent.Flush();

        }

        //select a page 
        public static Boolean SelectAPage(this IWebDriver driver, int pageNumber, string xPathForListOfPages)
        {
            IList<IWebElement> listOfPages = CustomMethods.GetAllTheListValue(driver, xPathForListOfPages);
            int nextButton = (listOfPages.Count) - 1;

            //int temp = 0;

            if (listOfPages.Count - 2 >= pageNumber)
            {
                for (int i = 1; i < nextButton; i++)
                {
                    if (listOfPages[i].Displayed)
                    {
                        if (listOfPages[i].Text.Equals(pageNumber.ToString()))
                        {
                            listOfPages[i].ClickOnButton();
                            Thread.Sleep(3000);
                            //temp = i;
                            //break;
                            goto end;
                        }

                    }
                    else
                    {
                        for (int j = 1; j <= nextButton; j++)
                        {
                            listOfPages[nextButton].ClickOnButton();
                            if (listOfPages[j].Displayed)
                            {
                                if (listOfPages[j].Text.Equals(pageNumber.ToString()))
                                {
                                    listOfPages[j].ClickOnButton();
                                    Thread.Sleep(3000);
                                    //break;
                                    goto end;

                                }
                            }

                        }

                    }
                }
                end:
                return true;
            }
            else
            {
                return false;
            }



        }

        //public static Boolean IsElementPresent(this IWebDriver driver, string xPathOfElement, int timeInSeconds)
        //{
        //    WaitHelper.WaitForElementIfPresent(driver, timeInSeconds);
        //    try
        //    {
        //        IList<IWebElement> elements = driver.FindElements(By.XPath(xPathOfElement));
        //        if (elements.Count >= 1)
        //            return true;
        //        else
        //            return false;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return false;
        //    }


        //}


        //upload file through SendKeys
        //public static void UploadFileWithSendKeys(this string FileLocation, int FileCount, IWebElement uploadFile)
        //{
        //    BaseSetUpClass testBase = BaseSetUpClass.Create();
        //    if (testBase.BrowserType.Equals("Firefox"))
        //    {
        //        for (int i = 1; i <= FileCount; i++)
        //        {

        //            uploadFile.Click();

        //            Thread.Sleep(3000);
        //            SendKeys.SendWait(FileLocation);
        //            //Thread.Sleep(2000);
        //            Thread.Sleep(4000);
        //            SendKeys.SendWait(@"{ENTER}");
        //            Thread.Sleep(3000);
        //        }

        //    }
        //    else if (testBase.BrowserType.Equals("Chrome"))
        //    {
        //        for (int i = 1; i <= FileCount; i++)
        //        {
        //            uploadFile.Click();
        //            Thread.Sleep(4000);
        //            SendKeys.SendWait(FileLocation);
        //            Thread.Sleep(2000);
        //            SendKeys.SendWait(@"{ENTER}");
        //            Thread.Sleep(2000);
        //        }
        //    }
        //    else if (testBase.BrowserType.Equals("IE"))
        //    {
        //        for (int i = 1; i <= FileCount; i++)
        //        {
        //            uploadFile.Click();
        //            Thread.Sleep(2000);
        //            SendKeys.SendWait(FileLocation);
        //            Thread.Sleep(1000);
        //            SendKeys.SendWait(@"{ENTER}");
        //            Thread.Sleep(1000);
        //        }
        //    }


        //}


        // Upload File Through Auto IT

        //public static void UploadAFileWithAutoIT(this string FileLocation, int FileCount, IWebElement uploadFile)
        //{
        //    BaseSetUpClass testBase = BaseSetUpClass.Create();
        //    //WaitHelper.WaitForElement(driver);
        //    //AutoItX3 AutoIt.AutoItX = new AutoItX3();
        //    //AutoIt.AutoItX.WinActivate("File Upload");
        //    if (testBase.BrowserType.Equals("Firefox"))
        //    {
        //        for (int i = 1; i <= FileCount; i++)
        //        {
        //            uploadFile.Click();

        //            AutoIt.AutoItX.WinActivate("File Upload");
        //            Thread.Sleep(3000);
        //            AutoIt.AutoItX.Send(FileLocation);
        //            Thread.Sleep(2000);
        //            AutoIt.AutoItX.Send("{ENTER}");
        //            Thread.Sleep(2000);
        //        }

        //    }
        //    else if (testBase.BrowserType.Equals("Chrome"))
        //    {
        //        for (int i = 1; i <= FileCount; i++)
        //        {
        //            uploadFile.Click();

        //            AutoIt.AutoItX.WinActivate("Open");
        //            Thread.Sleep(3000);
        //            AutoIt.AutoItX.Send(FileLocation);
        //            Thread.Sleep(2000);
        //            AutoIt.AutoItX.Send("{ENTER}");
        //            Thread.Sleep(2000);
        //        }
        //    }
        //    else if (testBase.BrowserType.Equals("IE"))
        //    {
        //        for (int i = 1; i <= FileCount; i++)
        //        {
        //            uploadFile.Click();

        //            AutoIt.AutoItX.WinActivate("Open");
        //            AutoIt.AutoItX.Send(FileLocation);
        //            Thread.Sleep(1000);
        //            AutoIt.AutoItX.Send("{ENTER}");
        //        }
        //    }

        //}        


    }
}
