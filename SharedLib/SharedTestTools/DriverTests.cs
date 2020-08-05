using NUnit.Framework;
using PageObjectModels;
using PageObjModels;

namespace LoginTests
{
    public class DriverTests
    {
        private const int _sleepTime = 5;

        [Test]
        public void ChromeDirver_WorkingCorrectly_Test()
        {
            //Arange
            SpartaWebsite _chromeWebsite = new SpartaWebsite("chrome", _sleepTime, _sleepTime);

            //Act
            _chromeWebsite.loginPage.Visit();

            //Assert
            Assert.That(_chromeWebsite.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));

            //Teardown
            _chromeWebsite.Close();
        }

        [Test]
        [Ignore("Firefox borwsers are not needed to be supported yet")]
        public void FirefoxDirver_WorkingCorrectly_Test()
        {
            //Arange
            SpartaWebsite _firefoxWebsite = new SpartaWebsite("firefox", _sleepTime, _sleepTime);

            //Act
            _firefoxWebsite.loginPage.Visit();

            //Assert
            Assert.That(_firefoxWebsite.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));

            //Teardown
            _firefoxWebsite.Close();
        }
    }
}