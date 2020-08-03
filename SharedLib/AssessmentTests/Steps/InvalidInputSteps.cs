using NUnit.Framework;
using PageObjectModels;
using System;
using TechTalk.SpecFlow;
using SharedTestTools;

namespace AssessmentTests.Steps
{
    [Binding]
    public class InvalidInputSteps
    {
        private SpartaWebsite _website;
        [BeforeScenario]
        public void setup()
        {
            _website = new SpartaWebsite("chrome");
        }

        [Given(@"I am in assessment page")]
        public void GivenIAmInAssessmentPage()
        {
            TestTools.Login(_website);

        }

        [Given(@"I have selected the (.*) to send")]
        public void GivenIHaveSelectedTheToSend(string course)
        {
            _website.assessmentPage.SelectAssessment(course);
        }

        [Given(@"I have entered  valid candidate name")]
        public void GivenIHaveEnteredValidCandidateName()
        {
            _website.assessmentPage.EnterCandidateName("Shwetha Ashwath");
        }

        [Given(@"I have invalid the Candidate email")]
        public void GivenIHaveInvalidTheCandidateEmail()
        {
            _website.assessmentPage.EnterCandidateEmail("shwetha21ashwath@gmail.com");
        }

        [Given(@"I have valid the Recruiter email (.*)")]
        public void GivenIHaveValidTheRecruiterEmail(string rEmail)
        {
            _website.assessmentPage.EnterRecruiterEmail(rEmail);
        }

        [Given(@"I have valid the Candidate email")]
        public void GivenIHaveValidTheCandidateEmail()
        {
            _website.assessmentPage.EnterCandidateEmail("shwetha21ashwath@gmail.com");
        }

        [Given(@"I have Invalid the Recruiter email (.*)")]
        public void GivenIHaveInvalidTheRecruiterEmail(string rEmail)
        {
            _website.assessmentPage.EnterRecruiterEmail(rEmail);
        }

        [Given(@"I have Invalid the Candidate email (.*)")]
        public void GivenIHaveInvalidTheCandidateEmail(string cemail)
        {
            _website.assessmentPage.EnterCandidateEmail(cemail);
        }

        [Given(@"I have valid the Recruiter email")]
        public void GivenIHaveValidTheRecruiterEmail()
        {
            _website.assessmentPage.EnterRecruiterEmail("shwetha21ashwath@gmail.com");
        }


        [When(@"I press the submit button")]
        public void WhenIPressTheSubmitButton()
        {
            _website.assessmentPage.SubmitDetails();
        }

        [Then(@"warning popup message should appear (.*)")]
        public void ThenWarningPopupMessageShouldAppear(string warning)
        {
            Assert.That(_website.assessmentPage.CaptureAlertMessage(), Is.EqualTo(warning));
        }

        [Then(@"i should be shown an error message (.*)")]
        public void ThenIShouldBeShownAnErrorMessage(string errormessage)
        {
            Assert.That(_website.assessmentPage.BadRequest(), Is.EqualTo(errormessage));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Dispose();
        }
    }
}
