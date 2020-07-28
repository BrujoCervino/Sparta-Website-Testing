using OpenQA.Selenium;
using SharedLib;

namespace PageObjectModel_Results
{
    public class ResultsPage : SuperPage
    {
        public ResultsPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/results";
        }
    }
}
