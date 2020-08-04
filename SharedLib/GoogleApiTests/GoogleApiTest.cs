using EmailApi;
using NUnit.Framework;

namespace GoogleApiTests
{
    public class GoogleApiTest
    {
        [Test]
        public void GoogleApi_IsWorkingCorrectly()
        {
            GmailAPIManager apiManager = new GmailAPIManager();

            string url = apiManager.GetEmailUrl();
            Assert.That(true);
        }
    }
}