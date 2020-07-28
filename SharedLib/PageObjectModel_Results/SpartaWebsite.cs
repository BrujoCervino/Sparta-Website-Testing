using OpenQA.Selenium;
using SharedLib;

namespace PageObjectModel_Results
{
    public class SpartaWebsite
    {
        public readonly ResultsPage resultsPage;
        public readonly IWebDriver SeleniumDriver;
        
        public SpartaWebsite(string driverName, int pageLoadInSeconds = 5, int implicitWaitInSeconds = 5)
        {
            SeleniumDriver = SeleniumDriverFactory.CreateDriver(driverName, pageLoadInSeconds, implicitWaitInSeconds);
            resultsPage = new ResultsPage(SeleniumDriver);
        }
    }
}
