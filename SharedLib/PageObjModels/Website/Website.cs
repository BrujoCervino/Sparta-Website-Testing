using OpenQA.Selenium;
using System;
using System.Threading;
using static PageObjectModels.Driver_Config.SeleniumDriverFactory;

namespace PageObjModels
{
    public abstract class Website
    {
        public readonly IWebDriver SeleniumDriver;

        public Website(string driverName, int pageLoadInSeconds = 5, int implicitWaitInSeconds = 5)
        {
            SeleniumDriver = CreateDriver(driverName, pageLoadInSeconds, implicitWaitInSeconds);
        }

        public string GetUrl() => SeleniumDriver.Url;

        public void SleepDriver(int sleepTime) => Thread.Sleep(TimeSpan.FromSeconds(sleepTime));

        public void Close() => SeleniumDriver.Dispose();
    }
}