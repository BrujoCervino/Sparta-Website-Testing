using APITestTools.SpartaAPI;
using EmailApi;
using PageObjectModels;
using PageObjModels;
using System;

namespace SharedTestTools
{
    public class TestTools
    {
        private delegate void TestAction();

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
            CodinGameWebsite codinGameWebsite = SetupCodinGameWebsite(browser);

            codinGameWebsite.DoTest();

            CloseCodinGameWebsite(codinGameWebsite);
        }

        public static void StartCodingTest(string browser)
        {
            //get test url
            CodinGameWebsite codinGameWebsite = SetupCodinGameWebsite(browser);

            codinGameWebsite.StatTest();

            CloseCodinGameWebsite(codinGameWebsite);
        }

        private static void CloseCodinGameWebsite(CodinGameWebsite codinGameWebsite)
        {
            codinGameWebsite.Close();
        }

        private static CodinGameWebsite SetupCodinGameWebsite(string browser)
        {
            GmailAPIManager apiManager = new GmailAPIManager();
            string url = apiManager.GetEmailUrl();

            //go to url
            CodinGameWebsite codinGameWebsite = new CodinGameWebsite(browser, url);
            codinGameWebsite.codinGamePage.Visit();
            codinGameWebsite.codinGamePage.MaximisePage();
            return codinGameWebsite;
        }
    }
}