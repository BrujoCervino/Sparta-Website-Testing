using OpenQA.Selenium;

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
}
