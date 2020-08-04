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

        [Given(@"A ""(.*)"" test has been sent out to ""(.*)""")]
        public void GivenATestHasBeenSentOutTo(string testType, string email)
        {
            TestTools.Login(_spartaWebsite);

            _spartaWebsite.assessmentPage.Visit();

            _spartaWebsite.assessmentPage.SelectAssessment(testType);
            _spartaWebsite.assessmentPage.EnterCandidateName("TestName");
            _spartaWebsite.assessmentPage.EnterCandidateEmail(email);
            _spartaWebsite.assessmentPage.EnterRecruiterEmail(email);
            _spartaWebsite.assessmentPage.ClickTitle();
            _spartaWebsite.assessmentPage.SubmitDetails();

            _spartaWebsite.SleepDriver(5);
        }

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
            _spartaWebsite.resultsPage.ClickUpdatebutton();
            _spartaWebsite.SleepDriver(10);
            _spartaWebsite.resultsPage.Visit();
        }

        [Then(@"there should be a new entry in the C\# results table")]
        public void ThenThereShouldBeANewEntryInTheCResultsTable()
        {
            List<List<string>> csharpResults = _spartaWebsite.resultsPage.GetCSharpResults();
            Assert.That(csharpResults[csharpResults.Count - 1][0], Is.EqualTo("TestName"));
        }
    }
}
