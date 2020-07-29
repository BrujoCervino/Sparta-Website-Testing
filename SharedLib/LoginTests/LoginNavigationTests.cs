using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteManager;

namespace LoginTests
{
    public class LoginNavigationTests
    {
        private Website _website;
        private const int _sleepTime = 5;

        [SetUp]
        public void Setup()
        {
            _website = new Website("firefox", _sleepTime, _sleepTime);
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