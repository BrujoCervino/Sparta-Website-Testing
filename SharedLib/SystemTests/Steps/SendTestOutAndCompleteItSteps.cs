using NUnit.Framework;
using PageObjModels;
using SharedTestTools;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SystemTests.Steps
{
    [Binding]
    public class SendTestOutAndCompleteItSteps
    {
        private SpartaWebsite _spartaWebsite;
        private int oldNumOfResults, sleepTime = 7;

        #region Setup/Teardown
        [BeforeScenario]
        public void BeforeScenario()
        {
            _spartaWebsite = new SpartaWebsite("chrome", 10,10);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _spartaWebsite.Close();
        }
        #endregion

        #region Arange
        [Given(@"""(.*)"" has been sent a ""(.*)"" test to ""(.*)""")]
        public void GivenHasBeenSentATestTo(string name, string testType, string email)
        {
            TestTools.Login(_spartaWebsite);

            _spartaWebsite.assessmentPage.Visit();

            _spartaWebsite.assessmentPage.SelectAssessment(testType);
            _spartaWebsite.assessmentPage.EnterCandidateName(name);
            _spartaWebsite.assessmentPage.EnterCandidateEmail(email);
            _spartaWebsite.assessmentPage.EnterRecruiterEmail(email);
            _spartaWebsite.assessmentPage.ClickTitle();
            _spartaWebsite.assessmentPage.SubmitDetails();

            _spartaWebsite.SleepDriver(sleepTime);
        }

        [Given(@"I login to the Website")]
        public void GivenILoginToTheWebsite()
        {
            TestTools.Login(_spartaWebsite);
        }

        [Given(@"I navigate to the results page")]
        public void GivenINavigateToTheResultsPage()
        {
            _spartaWebsite.assessmentPage.ClickResults();
        }
        #endregion

        #region Act
        [When(@"the test has been completed")]
        public void WhenTheTestHasBeenCompleted()
        {
            TestTools.DoCodingGameTest("chrome");
        }

        [When(@"I go to the results page")]
        public void WhenIGoToTheResultsPage()
        {
            _spartaWebsite.resultsPage.Visit();
        }

        [When(@"The results have been updated")]
        public void WhenTheResultsHaveBeenUpdated()
        {
            oldNumOfResults = _spartaWebsite.resultsPage.GetCSharpResults().Count;

            _spartaWebsite.resultsPage.ClickUpdatebutton();
            _spartaWebsite.SleepDriver(sleepTime);
            _spartaWebsite.resultsPage.Visit();
        }

        [When(@"The update button has been clicked")]
        public void WhenTheUpdateButtonHasBeenClicked()
        {
            _spartaWebsite.resultsPage.ClickUpdatebutton();
            _spartaWebsite.SleepDriver(sleepTime);
        }

        [When(@"I go to Dispatches page")]
        public void WhenIGoToDispatchesPage()
        {
            _spartaWebsite.dispatchesPage.Visit();
        }

        [When(@"the test has been started")]
        public void WhenTheTestHasBeenStarted()
        {
            TestTools.StartCodingTest("chrome");
        }

        [When(@"I go to Polls page")]
        public void WhenIGoToPollsPage()
        {
            _spartaWebsite.pollsPage.Visit();
        }

        [When(@"I click to the results page")]
        public void WhenIClickToTheResultsPage()
        {
            _spartaWebsite.assessmentPage.ClickResults();
        }

        [When(@"I lick to Dispatches page")]
        public void WhenILickToDispatchesPage()
        {
            _spartaWebsite.resultsPage.ClickDispatches();
        }

        [When(@"I click to Polls page")]
        public void WhenIClickToPollsPage()
        {
            _spartaWebsite.dispatchesPage.ClickPolls();
        }


        [When(@"I press Logout")]
        public void WhenIPressLogout()
        {
            _spartaWebsite.pollsPage.Clicklogout();
        }
        #endregion

        #region Assert
        [Then(@"""(.*)"" should bave a new entry in the C\# results table")]
        public void ThenShouldBaveANewEntryInTheCResultsTable(string name)
        {
            List<List<string>> csharpResults = _spartaWebsite.resultsPage.GetCSharpResults();
            Assert.That(csharpResults[csharpResults.Count - 1][0], Is.EqualTo(name));
        }

        [Then(@"the C\# results count has increased by one")]
        public void ThenTheCResultsCountHasIncreasedByOne()
        {
            List<List<string>> csharpResults = _spartaWebsite.resultsPage.GetCSharpResults();
            Assert.That(csharpResults.Count, Is.EqualTo(oldNumOfResults + 1));
        }


        [Then(@"""(.*)"" status under complete should be dislayed as ""(.*)""")]
        public void ThenStatusUnderCompleteShouldBeDislayedAs(string name, string status)
        {
            List<List<string>> data = _spartaWebsite.dispatchesPage.GetTableData(1);
            Assert.That(name, Is.EqualTo(data[0][0]));
            Assert.That(status, Is.EqualTo(data[0][6]));
        }

        [Then(@"Status of the matching test id is ""(.*)""")]
        public void ThenStatusOfTheMatchingTestIdIs(string status)
        {
            _spartaWebsite.dispatchesPage.Visit();
            List<List<string>> dispatchdata = _spartaWebsite.dispatchesPage.GetTableData(1);
            _spartaWebsite.pollsPage.Visit();
            List<List<string>> pollsdata = _spartaWebsite.pollsPage.GetTableData(1);
            Assert.That(dispatchdata[0][4], Is.EqualTo(pollsdata[0][3]));
            Assert.That(status, Is.EqualTo(pollsdata[0][1]));

        }

        [Then(@"""(.*)""should be displayed")]
        public void ThenShouldBeDisplayed(string message)
        {
            Assert.That(_spartaWebsite.logoutConfirmationPage.GetSuccessMsg(), Does.Contain(message));
        }

        [Then(@"the url should contain ""(.*)""")]
        public void ThenTheUrlShouldContain(string urlSection)
        {
            Assert.That(_spartaWebsite.GetUrl(), Does.Contain(urlSection));
        }
        #endregion
    }
}
