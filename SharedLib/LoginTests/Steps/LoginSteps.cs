using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModels;
using TechTalk.SpecFlow;

namespace LoginTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private SpartaWebsite _website;

        #region Setup/Teardown
        [BeforeScenario]
        public void Setup()
        {
            _website = new SpartaWebsite("chrome");
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.Close();
        }
        #endregion

        #region Arrage
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

        [Given(@"I enter my valid username")]
        public void GivenIEnterMyValidUsername()
        {
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
        }

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

        [Given(@"I am on Chrome browser")]
        public void GivenIAmOnChromeBrowser()
        {
            _website = new SpartaWebsite("chrome");
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            _website.loginPage.Visit();
        }

        [Given(@"I entern my valid username")]
        public void GivenIEnternMyValidUsername()
        {
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
        }
        #endregion

        #region Act       
        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            _website.loginPage.SubmitLoginInfo();
        }

        [When(@"I type in the home page url")]
        public void WhenITypeInTheHomePageUrl()
        {
            _website.assessmentPage.Visit();
        }

        [When(@"I press the Sparta logo")]
        public void WhenIPressTheSpartaLogo()
        {
            _website.SeleniumDriver.FindElement(By.CssSelector("body > nav > a > img")).Click();
        }

        [When(@"I type in the results page url")]
        public void WhenITypeInTheResultsPageUrl()
        {
            _website.resultsPage.Visit();
        }

        [When(@"I type in the dispatches page url")]
        public void WhenITypeInTheDispatchesPageUrl()
        {
            _website.dispatchesPage.Visit();
        }

        //[When(@"I type in the polling page url")]
        //public void WhenITypeInThePollingPageUrl()
        //{
        //    _spartaWebsite.pollingPage.Visit();
        //}

        [When(@"I type in the register page url")]
        public void WhenITypeInTheRegisterPageUrl()
        {
            _website.SeleniumDriver.Navigate().GoToUrl(PagesConfigReader.BaseUrl + "/register");
        }
        #endregion

        #region Assert
        [Then(@"the error message should be ""(.*)""")]
        public void ThenTheErrorMessageShouldBe(string errorMsg)
        {
            Assert.That(errorMsg, Is.EqualTo(_website.loginPage.GetErrorMsg()));
        }

        [Then(@"I should be on the login page")]
        public void ThenIShouldBeOnTheLoginPage()
        {
            Assert.That(_website.SeleniumDriver.FindElement(By.Id("login_title")).Displayed, Is.True);
        }

        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string noTokenMessage)
        {
            Assert.That(_website.loginPage.GetErrorMsg, Is.EqualTo(noTokenMessage));
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string pageTitle)
        {
            Assert.That(pageTitle, Is.EqualTo(_website.loginPage.GetPageTitle()));
        }
        #endregion
    }
}