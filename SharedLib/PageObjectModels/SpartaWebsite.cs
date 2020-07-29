using OpenQA.Selenium;
using PageObjectModels.POM;
using ResultsPageObject;
using System;
using System.Threading;
using static PageObjectModels.Driver_Config.SeleniumDriverFactory;

namespace PageObjectModels
{
    // This should maybe inherit from the page class.
    public class SpartaWebsite
    {
        public readonly ResultsPage resultsPage;
        public readonly LoginPage loginPage;
        public readonly DispatchesPage dispatchesPage;
        public readonly IWebDriver SeleniumDriver;

        public SpartaWebsite(string driverName, int pageLoadInSeconds = 5, int implicitWaitInSeconds = 5)
        {
            SeleniumDriver = CreateDriver(driverName, pageLoadInSeconds, implicitWaitInSeconds);
            resultsPage = new ResultsPage(SeleniumDriver);
            loginPage = new LoginPage(SeleniumDriver);
            dispatchesPage = new DispatchesPage(SeleniumDriver);
        }

        internal void SleepDriver(int sleepTime) => Thread.Sleep(TimeSpan.FromSeconds(sleepTime));

        public void Close() => SeleniumDriver.Dispose();

        public string GetUrl() => SeleniumDriver.Url;
    }
}