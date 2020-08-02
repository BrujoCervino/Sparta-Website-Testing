using NUnit.Framework;
using PageObjectModels;

namespace LoginTests
{
    public class DriverTests
    {
        private SpartaWebsite _chromeWebsite, _firefoxWebsite;
        private const int _sleepTime = 5;

        [Test]
        public void ChromeDirver_WorkingCorrectly_Test()
        {
            _chromeWebsite = new SpartaWebsite("chrome");

            _chromeWebsite.loginPage.Visit();
            Assert.That(_chromeWebsite.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));

            _chromeWebsite.Close();
        }

        [Test]
        [Ignore("Firefox borwsers are not needed to be supported yet")]
        public void FirefoxDirver_WorkingCorrectly_Test()
        {
            _firefoxWebsite = new SpartaWebsite("firefox", _sleepTime, _sleepTime);

            _firefoxWebsite.loginPage.Visit();
            Assert.That(_firefoxWebsite.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));
            
            _firefoxWebsite.Close();
        }
    }
}