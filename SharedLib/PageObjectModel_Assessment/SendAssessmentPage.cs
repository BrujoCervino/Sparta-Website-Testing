
using OpenQA.Selenium;
using SharedLib;

namespace PageObjectModel_Assessment
{
    public class SendAssessmentPage : SuperPage
    {
        public SendAssessmentPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/";
        }

    }
}
