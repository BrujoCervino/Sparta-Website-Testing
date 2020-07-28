﻿using OpenQA.Selenium;
using SharedLib;
using OpenQA.Selenium.Support.UI;



namespace AssessmentPageObject
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

        public void SubmitDetails() => submitButton.Click();

        public void SendPsychometric()
        {
            psychometriccheckbox.Click();
        }

        public void SelectAssessment(string cource)
        {
            asessmentDropDown.SelectByText("cource");
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
    }
}
