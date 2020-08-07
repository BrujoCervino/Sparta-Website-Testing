using NUnit.Framework;
using OpenQA.Selenium;
using PageObjModels;
using SharedTestTools;
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
        public void ChecktableData()
        {
            TestTools.Login(_website);

            _website.pollsPage.Visit();

            List<List<string>> pollsData = _website.pollsPage.GetTableData(100);

            Assert.That(pollsData[0][0], Is.EqualTo("August 3rd 2020, 10:50 am"));
        }

        [Test]
        public void CheckFormat_OfGivenRows()
        {
            //Correct format should be 12hr.
            TestTools.Login(_website);

            _website.pollsPage.Visit();

            Assert.That(_website.pollsPage.CheckDateFormatInTable(numOfRows:20), Is.EqualTo(true));

        }

        [Test]
        public void CheckStatus_OfGivenRows()
        {
            //Values will constantly change since status is dependant on users interaction with test
            //Input number of rows to check against, to return status's of rows given
            TestTools.Login(_website);

            _website.pollsPage.Visit();

            Assert.That(_website.pollsPage.CheckStatus(numOfRows:10), Is.EqualTo("completed: 0, in progress: 3, waiting: 7, aborted: 0, number of rows skipped: 0"));

        }

        [TearDown]
        public void TearDown()
        {
            _website.Close();
        }
    }
}
