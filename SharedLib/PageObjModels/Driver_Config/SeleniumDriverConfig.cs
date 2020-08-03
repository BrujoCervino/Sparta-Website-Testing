using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace PageObjectModels.Driver_Config
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
            FirefoxOptions fo = new FirefoxOptions { BrowserExecutableLocation = BrowserConfigReader.FirefoxLocation };
            Driver = string.IsNullOrWhiteSpace(fo.BrowserExecutableLocation) ? new FirefoxDriver() : new FirefoxDriver(fo);          
        }

        //Has to be the selienium driver location not your browers
        private void SetChromeDriver()
        {
            string chromeDriverLocation = BrowserConfigReader.ChromeLocation;
            Driver = string.IsNullOrWhiteSpace(chromeDriverLocation) ? new ChromeDriver() : new ChromeDriver(chromeDriverLocation);
        }
    }
}
