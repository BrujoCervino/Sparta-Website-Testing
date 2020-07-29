using OpenQA.Selenium;
using static SharedLib.SeleniumDriverFactory;

namespace ResultsPageObject
{
    // This should live inside the lib project.
    // This should maybe inherit from the page class.
    public class SpartaWebsite
    {
        public readonly ResultsPage resultsPage;
        public readonly IWebDriver SeleniumDriver;

        public SpartaWebsite(string driverName, int pageLoadInSeconds = 5, int implicitWaitInSeconds = 5)
        {
            SeleniumDriver = CreateDriver(driverName, pageLoadInSeconds, implicitWaitInSeconds);
            resultsPage = new ResultsPage(SeleniumDriver);
        }
    }
}