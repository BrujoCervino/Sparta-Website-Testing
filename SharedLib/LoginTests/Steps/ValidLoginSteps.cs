using NUnit.Framework;
using PageObjectModels;
using System;
using TechTalk.SpecFlow;

namespace LoginTests.Steps
{
    [Binding]
    public class ValidLoginSteps
    {
        private SpartaWebsite _website;

        [BeforeScenario]
        public void Before()
        {
            _website = new SpartaWebsite("chrome");
        }

        [Given(@"that I am on the login page")]
        public void GivenThatIAmOnTheLoginPage()
        {
            _website.loginPage.Visit();
        }

        [When(@"I entern my username")]
        public void WhenIEnternMyUsername()
        {
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
        }

        [When(@"I enter my password")]
        public void WhenIEnterMyPassword()
        {
            _website.loginPage.EnterPassword(LoginConfigReader.Password);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            Assert.That(expectedTitle, Is.EqualTo(_website.assessmentPage.GetPageTitle()));
        }

        [AfterScenario]
        public void After()
        {
            _website.Close();
        }
    }
}
