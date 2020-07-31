using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModels;
using TechTalk.SpecFlow;

namespace LoginTests
{
    [Binding]
    public class NoAccessTestsSteps
    {
        private SpartaWebsite _spartaWebsite;

        [Given(@"I am on Chrome browser")]
        public void GivenIAmOnChromeBrowser()
        {
            _spartaWebsite = new SpartaWebsite("chrome");
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            _spartaWebsite.loginPage.Visit();
        }

        [When(@"I press the Sparta logo")]
        public void WhenIPressTheSpartaLogo()
        {
            _spartaWebsite.SeleniumDriver.FindElement(By.CssSelector("body > nav > a > img")).Click();
        }

        [When(@"I type in the results page url")]
        public void WhenITypeInTheResultsPageUrl()
        {
            _spartaWebsite.resultsPage.Visit();
        }

        [When(@"I type in the dispatches page url")]
        public void WhenITypeInTheDispatchesPageUrl()
        {
            _spartaWebsite.dispatchesPage.Visit();
        }

        //[When(@"I type in the polling page url")]
        //public void WhenITypeInThePollingPageUrl()
        //{
        //    _spartaWebsite.pollingPage.Visit();
        //}

        [When(@"I type in the register page url")]
        public void WhenITypeInTheRegisterPageUrl()
        {
            _spartaWebsite.SeleniumDriver.Navigate().GoToUrl(PagesConfigReader.BaseUrl + "/register"); 
        }


        [Then(@"I should be on the login page")]
        public void ThenIShouldBeOnTheLoginPage()
        {
            Assert.That(_spartaWebsite.SeleniumDriver.FindElement(By.Id("login_title")).Displayed, Is.True);
        }

        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string noTokenMessage)
        {
            Assert.That(_spartaWebsite.loginPage.GetErrorMsg, Is.EqualTo(noTokenMessage));
        }
        [AfterScenario]
        public void DisposeWebDriver()
        {
            _spartaWebsite.SeleniumDriver.Dispose();
        }
    }
}
