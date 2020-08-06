using System.Threading;
using EmailApi;
using NUnit.Framework;
using PageObjModels;
using SharedTestTools;

namespace GoogleApiTests
{
    public class GoogleApiTest
    {
        [Test]
        public void GoogleApi_IsWorkingCorrectly()
        {
            GmailAPIManager apiManager = new GmailAPIManager();
            string url = apiManager.GetEmailUrl(out string msgID);

            //go to url
            CodinGameWebsite codingGameWebsite = new CodinGameWebsite("chrome", url);
            codingGameWebsite.codinGamePage.Visit();

            Assert.That(codingGameWebsite.GetUrl(), Does.StartWith("https://www.codingame.com/evaluate/"));

            codingGameWebsite.Close();
        }

    }
}