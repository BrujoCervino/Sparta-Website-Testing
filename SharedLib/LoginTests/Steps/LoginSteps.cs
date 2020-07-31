using NUnit.Framework;
using PageObjectModels;
using System;
using TechTalk.SpecFlow;

namespace LoginTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private SpartaWebsite _website;

        [BeforeScenario]
        public void Setup()
        {
            _website = new SpartaWebsite("chrome");
        }

        [Given(@"that I am on the login page")]
        public void GivenThatIAmOnTheLoginPage()
        {
            _website.loginPage.Visit();
        }

        [Given(@"I entered my valid username")]
        public void GivenIEnteredMyValidUsername()
        {
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
        }

        [Given(@"I entered (.*) as a password")]
        public void GivenIEnteredAsAPassword(string password)
        {
            _website.loginPage.EnterPassword(password);
        }

        [Given(@"I entered (.*) as a username")]
        public void GivenIEnteredAsAUsername(string username)
        {
            _website.loginPage.EnterUsername(username);
        }

        [Given(@"I enter my valid password")]
        public void GivenIEnterMyValidPassword()
        {
            _website.loginPage.EnterPassword(LoginConfigReader.Password);
        }

        //[Given(@"I entered an empty as a username")]
        //public void GivenIEnteredAnEmptyAsAUsername()
        //{
        //    _website.loginPage.EnterUsername("");
        //}

        [Given(@"I enter my valid username")]
        public void GivenIEnterMyValidUsername()
        {
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
        }

        //[Given(@"I entered an empty as a password")]
        //public void GivenIEnteredAnEmptyAsAPassword()
        //{
        //    _website.loginPage.EnterPassword("");
        //}

        [Given(@"I entered nothing into the username textbox")]
        public void GivenIEnteredNothingIntoTheUsernameTextbox()
        {
            _website.loginPage.EnterUsername("");
        }

        [Given(@"I entered nothing into the password textbox")]
        public void GivenIEnteredNothingIntoThePasswordTextbox()
        {
            _website.loginPage.EnterPassword("");
        }


        [Given(@"I entern my valid username")]
        public void GivenIEnternMyValidUsername()
        {
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string pageTitle)
        {
            Assert.That(pageTitle, Is.EqualTo(_website.loginPage.GetPageTitle()));
        }


        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            _website.loginPage.SubmitLoginInfo();
        }

        [Then(@"the error message should be ""(.*)""")]
        public void ThenTheErrorMessageShouldBe(string errorMsg)
        {
            Assert.That(errorMsg, Is.EqualTo(_website.loginPage.GetErrorMsg()));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _website.Close();
        }
    }
}
