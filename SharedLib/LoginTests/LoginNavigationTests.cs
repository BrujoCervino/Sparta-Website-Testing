using NUnit.Framework;
using PageObjectModels;

namespace LoginTests
{
    public class LoginNavigationTests
    {
        private SpartaWebsite  _website;
        private const int _sleepTime = 5;

        [SetUp]
        public void Setup()
        {
            _website = new SpartaWebsite("firefox", _sleepTime, _sleepTime);
        }

        [Test]
        public void DirverWorkingTest()
        {
            _website.loginPage.Visit();
            Assert.That(_website.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));
        }

        [TearDown]
        public void TearDown()
        {
            _website.Close();
        }
    }
}