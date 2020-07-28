using LoginPageObject;
using OpenQA.Selenium;
using SharedLib;
using System;
using System.Threading;

namespace WebsiteManager
{
    public class Website
    {
        public readonly IWebDriver seleniumDriver;
        public readonly LoginPage loginPage;

        public Website(string driverName, int pageLoadWaitInSecs = 10, int implicitWaitInSecs = 10)
        {
            seleniumDriver = SeleniumDriverFactory.CreateDriver(driverName, pageLoadWaitInSecs, implicitWaitInSecs);
            loginPage = new LoginPage(seleniumDriver);
        }

        internal void SleepDriver(int sleepTime) => Thread.Sleep(TimeSpan.FromSeconds(sleepTime));

        public void Close() => seleniumDriver.Dispose();

        public string GetUrl() => seleniumDriver.Url;
    }
}