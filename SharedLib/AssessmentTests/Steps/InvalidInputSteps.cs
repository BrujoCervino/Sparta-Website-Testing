using NUnit.Framework;
using PageObjModels;
using SharedTestTools;
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

        #region Arrage
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

        [Given(@"I have entered Invalid candidate name (.*)")]
        public void GivenIHaveEnteredInvalidCandidateName(string name)
        {
            _website.assessmentPage.EnterCandidateName(name);
        }

        [Given(@"None of the text boxes are in focus")]
        public void GivenNoneOfTheTextBoxesAreInFocus()
        {
            _website.assessmentPage.ClickTitle();
        }

        #endregion


        #region Act
        [When(@"I press the submit button")]
        public void WhenIPressTheSubmitButton()
        {
            _website.assessmentPage.SubmitDetails();
        }
        #endregion

        #region Assert
        [Then(@"i should be shown an error message (.*)")]
        public void ThenIShouldBeShownAnErrorMessage(string errormessage)
        {
            Assert.That(_website.assessmentPage.BadRequest(), Is.EqualTo(errormessage));
        }


        [Then(@"I shouldn't get a message Assessment Sent")]
        public void ThenIShouldnTGetAMessageAssessmentSent()
        {
            Assert.That(_website.assessmentPage.Success(), Is.Not.EqualTo("Assessment Sent"));
        }


        #endregion


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Dispose();
        }
    }
}
