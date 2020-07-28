namespace SharedLib
{
    // Exists for people whose browsers are not in the default location
    public class BrowserConfigReader : ConfigReader
    {
        public static readonly string FirefoxLocation = configObj.browserLocations.Firefox;
    }
}