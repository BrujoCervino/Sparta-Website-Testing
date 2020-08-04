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
            string url = apiManager.GetEmailUrl();

            //go to url
            CondingGameWebsite codingGameWebsite = new CondingGameWebsite("chrome", url);
            codingGameWebsite.codingGamePage.Visit();

            Assert.That(codingGameWebsite.GetUrl(), Does.StartWith("https://www.codingame.com/evaluate/"));

            codingGameWebsite.Close();
        }       
    }
}