using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace testing.Factories
{
    public static class DriverFactory
    {
        public static IWebDriver driver;
        static ChromeOptions options;

        public static void LauchDriver(bool debuggingMode=false) 
        {
            if (debuggingMode)
            {
                options = new ChromeOptions
                {
                    DebuggerAddress = "127.0.0.1:9222"
                };
                driver = new ChromeDriver(options);
            }
            else 
            {
                driver = new ChromeDriver();
                //driver.Manage().Window.Maximize();
            }
            

        }

        
        public static void TearDownDriver()
        {
            driver.Quit();
            driver = null;
        }

        public static Screenshot TakeSS() {
            return (driver as ITakesScreenshot).GetScreenshot();
        }

        public static void waitForElement(string locator, double time) {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
        }

        public static void waitForVisibility(string locator, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        }

        public static void waitForInvisibility(string locator, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locator)));
        }

        public static void waitForElement(IWebElement element, double time)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
