using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using testing.Factories;


namespace testing.Helpers
{
    public class Utilities
    {

        public static void NavigateDriver(string url) {
            DriverFactory.driver.Navigate().GoToUrl(url);
        }
        public static void EnterString(string locatorValue, string fieldValue)
        {
            WaitFactory.WaitForElementToBeClickable(locatorValue);
            IWebElement element = ElementFactory.GetElement(locatorValue);
            EnterString(element, fieldValue);
        }

        public static void EnterString(IWebElement element, string fieldValue)
        {
            DriverFactory.waitForElement(element, 10);
            element.Clear();
            element.SendKeys(fieldValue);
        }
        
        public static void EnterStringUsingAction(string locatorValue, string fieldValue)
        {
            WaitFactory.WaitForElementToBeClickable(locatorValue);
            IWebElement element = ElementFactory.GetElement(locatorValue);
            element.Clear();
            new Actions(DriverFactory.driver)
               .SendKeys(element, fieldValue)
               .SendKeys(Keys.Return)
               .Perform();
        }
        public static void HoverUsingAction(string locatorValue)
        {
            WaitFactory.WaitForElementToBeClickable(locatorValue);
            IWebElement element = ElementFactory.GetElement(locatorValue);
            new Actions(DriverFactory.driver)
                .MoveToElement(element)
                .Perform();
        }

        public static void ClickElement(string locatorValue)
        {
            IWebElement element = ElementFactory.GetElement(locatorValue);
            ClickElement(element);
        }
        public static void ClickElement(IWebElement element)
        {
            DriverFactory.waitForElement(element, 10);
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static bool IsElementVisible(string locatorValue)
        {
            try 
            {
                DriverFactory.waitForVisibility(locatorValue, 10);
                return ElementFactory.IsElementVisible(locatorValue);
            }
            catch 
            { 
                return false; 
            }
            
        }

        public static bool IsElementNotVisible(string locatorValue)
        {
            try
            {
                DriverFactory.waitForInvisibility(locatorValue, 10);
                return !ElementFactory.IsElementVisible(locatorValue);
            }
            catch
            {
                return false;
            }

        }

    }
}
