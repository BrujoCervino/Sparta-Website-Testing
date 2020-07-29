namespace PageObjectModels
{
    public class ConfigRoot
    {
        public string BaseUrl { get; set; }

        public Pages pages { get; set; }
        public LoginDetails loginDetails { get; set; }
        public Browserlocations browserLocations { get; set; }
    }

    public class Pages
    {
        public string Dispatches { get; set; }
        public string Polls { get; set; }
        public string Results { get; set; }
    }

    public class LoginDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Browserlocations
    {
        public string Firefox { get; set; }
    }
}