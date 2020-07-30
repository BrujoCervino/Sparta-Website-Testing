using NUnit.Framework;
using PageObjectModels;

namespace LoginTests
{
    public class LoginNavigationTests
    {
        private SpartaWebsite _chromeWebsite, _firefoxWebsite;
        private const int _sleepTime = 5;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ChromeDirver_WorkingCorrectly_Test()
        {
            _chromeWebsite = new SpartaWebsite("chrome", _sleepTime, _sleepTime);

            _chromeWebsite.loginPage.Visit();
            Assert.That(_chromeWebsite.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));
        }

        [Test]
        public void FirefoxDirver_WorkingCorrectly_Test()
        {
            _firefoxWebsite = new SpartaWebsite("firefox", _sleepTime, _sleepTime);

            _firefoxWebsite.loginPage.Visit();
            Assert.That(_firefoxWebsite.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));
        }

        [TearDown]
        public void TearDown()
        {
            if (_chromeWebsite != null)
                _chromeWebsite.Close();
            if (_firefoxWebsite != null)
                _firefoxWebsite.Close();
        }
    }
}