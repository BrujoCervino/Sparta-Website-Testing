using PageObjectModels.POM;

namespace PageObjModels
{
    public class SpartaWebsite : Website
    {
        public readonly AssessmentPage assessmentPage;
        public readonly ResultsPage resultsPage;
        public readonly LoginPage loginPage;
        public readonly DispatchesPage dispatchesPage;
        public readonly PollsPage pollsPage;

        public SpartaWebsite(string driverName, int pageLoadInSeconds = 5, int implicitWaitInSeconds = 5) : base(driverName, pageLoadInSeconds, implicitWaitInSeconds)
        {           
            assessmentPage = new AssessmentPage(SeleniumDriver);
            resultsPage = new ResultsPage(SeleniumDriver);
            loginPage = new LoginPage(SeleniumDriver);
            dispatchesPage = new DispatchesPage(SeleniumDriver);
            pollsPage = new PollsPage(SeleniumDriver);
        }
    }
}