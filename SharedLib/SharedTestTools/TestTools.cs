using APITestTools.SpartaAPI;
using PageObjectModels;

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
    }
}