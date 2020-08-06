using NUnit.Framework;
using PageObjModels;
using SharedTestTools;
using TechTalk.SpecFlow;

namespace DispatchesTests.Steps
{
    [Binding]
    public class PageAccessSteps
    {
        private SpartaWebsite _website;

        #region Setup/Teardown
        [BeforeScenario]
        public void Setup()
        {
            _website = new SpartaWebsite("chrome");
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.Close();
        }
        #endregion

        #region Arrage

        [Given(@"I am logged in correctly")]
        public void GivenIAmLoggedInCorrectly()
        {
            TestTools.Login(_website);
        }

        #endregion

        #region Act 

        [When(@"I naviage to the dispatches page")]
        public void WhenINaviageToTheDispatchesPage()
        {
            _website.dispatchesPage.Visit();
        }

        #endregion

        #region Assert 
        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string pageTitle)
        {
            Assert.That(_website.dispatchesPage.GetPageTitle, Is.EqualTo(pageTitle));
        }

        #endregion
    }
}
