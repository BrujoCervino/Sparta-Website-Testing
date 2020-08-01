using NUnit.Framework;
using PageObjectModels;
using System;
using TechTalk.SpecFlow;

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
            _website.loginPage.Visit();
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
            _website.loginPage.EnterPassword(LoginConfigReader.Password);
            _website.loginPage.SubmitLoginInfo();
            _website.assessmentPage.Visit();

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


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Dispose();
        }
    }
}
