using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;


namespace testing.Factories
{
    public static class WaitFactory
    {
        static int timeOutInMilliSecondsinint = 10000;
           

        public static void WaitForElementToBeClickable(string locatorValue)
        {
            Console.WriteLine("this is wait factory locator value" + locatorValue);
            WebDriverWait wait = new WebDriverWait(DriverFactory.driver, TimeSpan.FromMilliseconds(timeOutInMilliSecondsinint));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
        }
        public static void WaitForElementToBeVisible(string locatorValue)
        {
            Console.WriteLine("this is wait factory locator value" + locatorValue);
            WebDriverWait wait = new WebDriverWait(DriverFactory.driver, TimeSpan.FromMilliseconds(timeOutInMilliSecondsinint));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
        }
    }
}
