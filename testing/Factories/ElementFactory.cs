using OpenQA.Selenium;
using System;

namespace testing.Factories
{
    public class ElementFactory
    {

        public static IWebElement GetElement(string locatorValue)
        {
            IWebElement element;
            try
            {
                element = DriverFactory.driver.FindElement(By.XPath(locatorValue));
                return element;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool IsElementVisible(string locatorValue)
        {
            try
            {
                DriverFactory.driver.FindElement(By.XPath(locatorValue));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




    }
}
