using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SharedLib
{
    // "Factory Pattern" design pattern: means we don't have to keep writing "new SeleniumDriverConfig.Driver"
    public class SeleniumDriverFactory 
    {
        public static IWebDriver CreateDriver(in string driverName, in int pageLoadInSeconds, in int implicitWaitInSeconds)
        {
            return 
                new SeleniumDriverConfig(driverName, pageLoadInSeconds, implicitWaitInSeconds)
                .Driver;
        }
    }
    
    public class SeleniumDriverConfig
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDriverConfig(string driverName, int pageLoadInSeconds, int implicitWaitInSeconds)
        {
            DriverSetUp(driverName, pageLoadInSeconds, implicitWaitInSeconds);
        }

        private void DriverSetUp(string driverName, int pageLoadInSeconds, int implicitWaitInSeconds)
        {
            switch (driverName.ToLower())
            {
                case "chrome":
                    SetChromeDriver();
                    break;
                case "firefox":
                    SetFireFoxDriver();
                    break;
                default:
                    throw new ArgumentException("Use 'chrome' or 'firefox'");
            }

            SetDriverConfiguration(pageLoadInSeconds, implicitWaitInSeconds);
        }

        private void SetDriverConfiguration(int pageLoadInSeconds, int implicitWaitInSeconds)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSeconds);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSeconds);
        }

        private void SetFireFoxDriver()
        {
            FirefoxOptions fo = new FirefoxOptions { BrowserExecutableLocation = @"D:\Programmes\Mozilla Firefox" };
            Driver = new FirefoxDriver(fo);
        }

        private void SetChromeDriver()
        {
            Driver = new ChromeDriver();
        }
    }
}
