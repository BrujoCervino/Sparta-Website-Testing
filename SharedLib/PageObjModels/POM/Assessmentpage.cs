using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModels.POM
{
    public class AssessmentPage : NavigationObjs
    {
        private SelectElement asessmentDropDown => new SelectElement(_seleniumDriver.FindElement(By.Id("assessment")));
        private IWebElement candidateName => _seleniumDriver.FindElement(By.Id("candidate_name"));
        private IWebElement candidateEmail => _seleniumDriver.FindElement(By.Id("candidate_email"));
        private IWebElement recruiterEmail => _seleniumDriver.FindElement(By.Id("recruiter_email"));
        private IWebElement submitButton => _seleniumDriver.FindElement(By.Id("submit"));
        private IWebElement psychometriccheckbox => _seleniumDriver.FindElement(By.Id("checkbox"));
        private IWebElement errorMessage => _seleniumDriver.FindElement(By.TagName("h5"));
        private IWebElement assessmentSent => _seleniumDriver.FindElement(By.TagName("h1"));


        public AssessmentPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/";
        }

        public void EnterCandidateName(string candidate)
        {
            candidateName.Clear();
            candidateName.SendKeys(candidate);
        }

        public void EnterCandidateEmail(string cEmail)
        {
            candidateEmail.Clear();
            candidateEmail.SendKeys(cEmail);

        }

        public void EnterRecruiterEmail(string rEmail)
        {
            recruiterEmail.Clear();
            recruiterEmail.SendKeys(rEmail);
        }

        public void SubmitDetails()
        { 
            submitButton.Click();
        }

        public void SendPsychometric()
        {
            psychometriccheckbox.Click();
        }

        public void SelectAssessment(string course)
        {
           asessmentDropDown.SelectByValue(course);
        }

        public string CaptureAlertMessage()
        {
            var allertM = _seleniumDriver.SwitchTo().Alert();
            return allertM.ToString();
        }

        public string BadRequest()
        {
            return errorMessage.Text;
        }

        public string Success()
        {
            return assessmentSent.Text;
        }
    }
}
