using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModels;
using System.Collections.Generic;

namespace DispatchesTests
{
    public class GetTableValuesTests
    {
        private SpartaWebsite _website;
        private const int _sleepTime = 5;

        [SetUp]
        public void Setup()
        {
            _website = new SpartaWebsite("chrome", _sleepTime, _sleepTime);
            _website.loginPage.MaximisePage();
        }

        [Test]
        public void VisitPollsPageTest()
        {
            _website.pollsPage.Visit();
            Assert.That(_website.GetUrl(), Is.EqualTo(PagesConfigReader.PollsUrl));
        }

        [TestCase(1, "Poll Time")]
        [TestCase(2, "Status")]
        [TestCase(3, "Email")]
        [TestCase(4, "Test Id")]
        public void CheckColumnHeaderLoads(in int index, in string headerName) 
        {
            _website.loginPage.Visit();
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
            _website.loginPage.EnterPassword(LoginConfigReader.Password);
            _website.loginPage.SubmitLoginInfo();
            _website.pollsPage.Visit();

            IWebElement TestId = _website.SeleniumDriver.FindElement(By.CssSelector($"body > div > table > thead > tr > th:nth-child({index})"));

            Assert.That(TestId.Text, Is.EqualTo(headerName));
        }

        [Test]
        public void GetTableValues_ReturnValues()
        { // Fragile test, Will have to look further into it when further
            _website.loginPage.Visit();
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
            _website.loginPage.EnterPassword(LoginConfigReader.Password);
            _website.loginPage.SubmitLoginInfo();
            _website.pollsPage.Visit();
            _website.pollsPage.GetTableContent();
            // write a test that asserts if anyone's email from eng-58 exists in the polls page data

            List<string> emailList = new List<string>() {"shwetha21ashwath@gmail.com", "will.millington@btinternet.com", "Tperera@spartaglobal.com", "sunny.sahota989@gmail.com", "masimba36@outlook.com", "kmcevaddy@spartaglobal.com" };

            Assert.That(emailList, Does.Contain(_website.pollsPage.pollsList[1].Email));
        }

        [TearDown]
        public void TearDown()
        {
            _website.Close();
        }
    }
}
