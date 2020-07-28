using NUnit.Framework;
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
        public void Test1()
        {
            Assert.That(true);
        }
    }
}
