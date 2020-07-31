namespace PageObjectModels
{
    // Exists for people whose browsers are not in the default location
    public class BrowserConfigReader : ConfigReader
    {
        public static readonly string FirefoxLocation = configObj.browserLocations.Firefox;

        public static readonly string ChromeLocation = configObj.browserLocations.Chrome;
    }
}