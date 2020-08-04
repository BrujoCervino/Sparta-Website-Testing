using APITestTools.SpartaAPI;
using EmailApi;
using PageObjectModels;
using PageObjModels;

namespace SharedTestTools
{
    public class TestTools
    {
        public static void DeleteDispatches()
        {
            SpartaAPIService sparta = new SpartaAPIService();
            sparta.DeleteDispatches();
        }

        public static string GenerateWhiteSpaceString(int length) => new string(' ', length);

        public static void Login(SpartaWebsite website)
        {
            website.loginPage.Visit();
            website.loginPage.EnterUsername(LoginConfigReader.Username);
            website.loginPage.EnterPassword(LoginConfigReader.Password);
            website.loginPage.SubmitLoginInfo();
        }

        public static void DoCodingGameTest(string browser)
        {
            //get test url
            GmailAPIManager apiManager = new GmailAPIManager();
            string url = apiManager.GetEmailUrl();

            //go to url
            CondingGameWebsite codingGameWebsite = new CondingGameWebsite(browser, url);
            codingGameWebsite.codingGamePage.Visit();

            //do test here
            codingGameWebsite.DoTest();

            codingGameWebsite.Close();
        }
    }
}