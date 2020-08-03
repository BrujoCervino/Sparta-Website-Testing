using PageObjectModels;

namespace SharedTestTools
{
    public class TestTools
    {
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