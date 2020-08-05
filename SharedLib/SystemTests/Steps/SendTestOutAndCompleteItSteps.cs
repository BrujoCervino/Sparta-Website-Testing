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
        private int oldNumOfResults, sleepTime = 5;

        #region Setup/Teardown
        [BeforeScenario]
        public void BeforeScenario()
        {
            _spartaWebsite = new SpartaWebsite("chrome");
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
        #endregion
    }
}
