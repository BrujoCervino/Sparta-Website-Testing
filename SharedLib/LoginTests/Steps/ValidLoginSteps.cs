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

        [Given(@"I entern my valid username")]
        public void GivenIEnternMyValidUsername()
        {
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
        }

        [Given(@"I enter my valid password")]
        public void GivenIEnterMyValidPassword()
        {
            _website.loginPage.EnterPassword(LoginConfigReader.Password);
        }

        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            _website.loginPage.SubmitLoginInfo();
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
