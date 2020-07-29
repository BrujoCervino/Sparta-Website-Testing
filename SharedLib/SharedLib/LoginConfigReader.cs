namespace SharedLib
{
#warning This probably duplicates a class Tom has made. Replace it when possible. If not, Tom, please steal it :)

    public class LoginConfigReader : ConfigReader
    {
        public static readonly string Username = configObj.loginDetails.Username;
        public static readonly string Password = configObj.loginDetails.Password;
    }
}