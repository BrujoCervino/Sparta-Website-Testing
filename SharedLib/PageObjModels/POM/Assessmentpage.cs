using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace PageObjectModels.POM
{
    public class AssessmentPage : SuperPage
    {
        private SelectElement asessmentDropDown => new SelectElement(_seleniumDriver.FindElement(By.Id("assessment")));
        private IWebElement candidateName => _seleniumDriver.FindElement(By.Id("candidate_name"));
        private IWebElement candidateEmail => _seleniumDriver.FindElement(By.Id("candidate_email"));
        private IWebElement recruiterEmail => _seleniumDriver.FindElement(By.Id("recruiter_email"));
        private IWebElement submitButton => _seleniumDriver.FindElement(By.Id("submit"));
        private IWebElement psychometriccheckbox => _seleniumDriver.FindElement(By.Id("checkbox"));
        private IWebElement dispatches => _seleniumDriver.FindElement(By.CssSelector("[href *='/dispatches']"));
        private IWebElement results => _seleniumDriver.FindElement(By.CssSelector("[href *='/results']"));
        private IWebElement polls => _seleniumDriver.FindElement(By.CssSelector("[href *='/polls']"));
        private IWebElement logout => _seleniumDriver.FindElement(By.CssSelector("[href *='/logout']"));
        private IWebElement errorMessage => _seleniumDriver.FindElement(By.TagName("h5"));
       
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
            Thread.Sleep(3000);

        }

        public void EnterRecruiterEmail(string rEmail)
        {
            recruiterEmail.Clear();
            recruiterEmail.SendKeys(rEmail);
            Thread.Sleep(10000);

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

        public void GotoDispatch()
        {
            dispatches.Click();
        }

        public void Gotoresults()
        {
            results.Click();
        }

        public void GotoPolls()
        {
            polls.Click();
        }

        public void Logout()
        {
            logout.Click();
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
    }
}
