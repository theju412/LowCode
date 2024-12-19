using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Spaidy.PageObjects.Locators;
using System;
using System.Collections.ObjectModel;

namespace Spaidy.Utilities
{
    public static class WaitHelper
    {
        #region Implicit Wait
        public static void WaitForElement(this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }


        #endregion

        #region Implicit Wait for some Specific conditions
        public static void WaitForElementIfPresent(this IWebDriver driver, int timeInSeconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
        }
        #endregion

        #region Wait till page load completely
        public static void WaitUntillPageLoads(this IWebDriver driver)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(1);

        }
        #endregion

        #region Wait For Specific Element  - OLD
        public static WebDriverWait WaitForSpecificElement(this IWebDriver driver)
        {
            //This Wait apply to all Specific webelement
            //which can be customized later in test scripts
            WebDriverWait wait;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            return wait;
        }

        #endregion

        #region WaitTillElementIsVisible
        //An expectation for checking that an element is present
        //on the DOM of a page and visible.
        //Visibility means that the element is not only displayed but also has
        //a height and width that is greater than 0.
        public static WebDriverWait WaitTillElementIsVisible(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            return wait;
        }

        //overloaded function
        public static WebDriverWait WaitTillElementIsVisible(this IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            return wait;
        }



        #endregion

        #region WaitTillAlertIsPresent
        //An expectation for checking the Alert State
        public static WebDriverWait WaitTillAlertIsPresent(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        {
            //An expectation for checking the Alert State
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.AlertIsPresent());
            return wait;
        }
        //Overloaded function
        public static WebDriverWait WaitTillAlertIsPresent(this IWebDriver driver, int timeInSeconds)
        {
            //An expectation for checking the Alert State
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.AlertIsPresent());
            return wait;
        }
        #endregion

        #region WaitTillElementExist
        //An expectation for checking that an element is present on the DOM
        //of a Page. This does not necessarily mean that the element is visible.
        public static WebDriverWait WaitTillElementExist(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
            return wait;
        }
        //Overloaded function
        public static WebDriverWait WaitTillElementExist(this IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
            return wait;
        }

        #endregion

        #region WaitTillElementToBeClickable
        //An expectation for checking an element is visible and enabled
        //such that you can click it.
        public static WebDriverWait WaitTillElementToBeClickable(this IWebElement element, IWebDriver driver, int timeInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return wait;
        }
        //Overloaded Function
        public static WebDriverWait WaitTillElementToBeClickable(this IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
            return wait;
        }

        public static WebDriverWait WaitTillElementToBeClickable(this IWebDriver driver, IWebElement element, int timeInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return wait;
        }


        #endregion

        #region WaitTillElementToBeSelected
        //An expectation for checking if the given element is selected.
        public static WebDriverWait WaitTillElementToBeSelected(this IWebElement element, IWebDriver driver, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementToBeSelected(element));
            return wait;
        }
        //overloaded function with locator
        public static WebDriverWait WaitTillElementToBeSelected(this IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath(locator)));
            return wait;
        }
        //Overloaded function with boolean selected
        public static WebDriverWait WaitTillElementToBeSelected(this IWebElement element, IWebDriver driver, Boolean selected, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementToBeSelected(element, selected));
            return wait;
        }

        #endregion

        #region WaitTillInvisibilityOfElement
        //An expectation for checking that an element is either invisible
        //or not present on the DOM.
        public static WebDriverWait WaitTillInvisibilityOfElement(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locator)));
            return wait;
        }
        //Overloaded function with driver extension
        public static WebDriverWait WaitTillInvisibilityOfElement(this IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locator)));
            return wait;
        }
        #endregion

        #region WaitTillInvisibilityOfElementWithText
        //An expectation for checking that an element with text is either invisible or
        //not present on the DOM.
        public static WebDriverWait WaitTillInvisibilityOfElementWithText(this IWebElement element, IWebDriver driver, string locator, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath(locator), text));
            return wait;
        }
        //Overloaded function with driver extension
        public static WebDriverWait WaitTillInvisibilityOfElementWithText(this IWebDriver driver, string locator, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath(locator), text));
            return wait;
        }
        #endregion

        #region WaitTillPresenceOfAllElements
        //An expectation for checking that all elements present on the web page
        //that match the locator.
        public static WebDriverWait WaitTillPresenceOfAllElements(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(locator)));
            return wait;
        }
        //function overloading with driver extension
        public static WebDriverWait WaitTillPresenceOfAllElements(this IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(locator)));
            return wait;
        }



        #endregion

        #region WaitTillStalenessOfElement
        //Wait until an element is no longer attached to the DOM.
        public static WebDriverWait WaitTillStalenessOfElement(this IWebElement element, IWebDriver driver, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.StalenessOf(element));
            return wait;
        }

        public static WebDriverWait WaitTillStalenessOfElement(this IWebDriver driver, IWebElement element, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.StalenessOf(element));
            return wait;
        }

        #endregion

        #region WaitTillTextToBePresentInElement
        //An expectation for checking if the given text is present
        //in the specified element.
        public static WebDriverWait WaitTillTextToBePresentInElement(this IWebElement element, IWebDriver driver, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            return wait;
        }

        public static WebDriverWait WaitTillTextToBePresentInElement(this IWebDriver driver, IWebElement element, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            return wait;
        }

        #endregion

        #region WaitTillTextToBePresentInElementLocated
        //An expectation for checking if the given text is present
        //in the element that matches the given locator.
        public static WebDriverWait WaitTillTextToBePresentInElementLocated(this IWebElement element, IWebDriver driver, string locator, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath(locator), text));
            return wait;
        }

        public static WebDriverWait WaitTillTextToBePresentInElementLocated(this IWebDriver driver, string locator, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath(locator), text));
            return wait;
        }

        #endregion

        #region WaitTillTextToBePresentInElementValue
        //An expectation for checking if the given text is present
        //in the specified elements value attribute.
        public static WebDriverWait WaitTillTextToBePresentInElementValue(this IWebElement element, IWebDriver driver, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
            return wait;
        }

        public static WebDriverWait WaitTillTextToBePresentInElementValue(this IWebDriver driver, string locator, string text, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.XPath(locator), text));
            return wait;
        }

        public static WebDriverWait WaitTillTextToBePresentInElementValue(this IWebDriver driver, IWebElement element, string text, int timeInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
            return wait;
        }

        #endregion

        #region WaitTillTitleContains
        //An expectation for checking that the title of a page contains
        //a case-sensitive substring.
        //title: The expected title, which must be an exact match.
        public static WebDriverWait WaitTillTitleContains(this IWebElement element, IWebDriver driver, string title, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TitleContains(title));
            return wait;
        }

        public static WebDriverWait WaitTillTitleContains(this IWebDriver driver, string title, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TitleContains(title));
            return wait;
        }

        #endregion

        #region WaitTillTitleIs
        //An expectation for checking the title of a page.
        //title: The expected title, which must be an exact match.
        public static WebDriverWait WaitTillTitleIs(this IWebElement element, IWebDriver driver, string title, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TitleIs(title));
            return wait;
        }

        public static WebDriverWait WaitTillTitleIs(this IWebDriver driver, string title, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.TitleIs(title));
            return wait;
        }

        #endregion

        #region WaitTillUrlContains
        //An expectation for the URL of the current page to be a specific URL.
        //fraction: The fraction of the url that the page should be on
        public static WebDriverWait WaitTillUrlContains(this IWebElement element, IWebDriver driver, string url, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.UrlContains(url));
            return wait;
        }

        public static WebDriverWait WaitTillUrlContains(this IWebDriver driver, string url, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.UrlContains(url));
            return wait;
        }

        #endregion

        #region WaitTillUrlMatches
        //An expectation for the URL of the current page to be a specific URL.
        // Parameters:-> regex: The regular expression that the URL should match
        public static WebDriverWait WaitTillUrlMatches(this IWebElement element, IWebDriver driver, string url, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.UrlMatches(url));
            return wait;
        }

        public static WebDriverWait WaitTillUrlMatches(this IWebDriver driver, string url, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.UrlMatches(url));
            return wait;
        }

        #endregion

        #region WaitTillUrlToBe
        //An expectation for the URL of the current page to be a specific URL.
        //url: The URL that the page should be on
        public static WebDriverWait WaitTillUrlToBe(this IWebElement element, IWebDriver driver, string url, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.UrlToBe(url));
            return wait;
        }

        public static WebDriverWait WaitTillUrlToBe(this IWebDriver driver, string url, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.UrlToBe(url));
            return wait;
        }

        #endregion

        #region WaitTillVisibilityOfAllElements
        //An expectation for checking that all elements present on the web page
        //that match the locator are visible.
        //Visibility means that the elements are not only displayed
        //but also have a height and width that is greater than 0.
        public static WebDriverWait WaitTillVisibilityOfAllElements(this ReadOnlyCollection<IWebElement> elements, IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
            return wait;
        }

        public static WebDriverWait WaitTillVisibilityOfAllElements(this IWebElement element, IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(locator)));
            return wait;
        }

        public static WebDriverWait WaitTillVisibilityOfAllElements(this IWebDriver driver, string locator, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(locator)));
            return wait;
        }

        #endregion

        #region WaitTillLoading - Ajax wheel Call
        ////Wait till Ajax call is not displayed
        //public static void WaitTillLoading(this IWebDriver driver, int timeInSeconds)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
        //    wait.Until(d => !d.FindElement(By.XPath(LoginPageLocator.WaitTillLoadingWheelAppears)).Displayed);

        //}

        #endregion

    }
}
