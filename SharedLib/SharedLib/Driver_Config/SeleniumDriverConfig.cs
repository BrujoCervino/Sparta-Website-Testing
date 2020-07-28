using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SharedLib
{
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
