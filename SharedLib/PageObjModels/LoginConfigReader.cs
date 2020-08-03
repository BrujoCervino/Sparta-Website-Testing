namespace PageObjectModels
{
    public class LoginConfigReader : ConfigReader
    {
        public static readonly string Username = configObj.loginDetails.Username;
        public static readonly string Password = configObj.loginDetails.Password;
    }
}