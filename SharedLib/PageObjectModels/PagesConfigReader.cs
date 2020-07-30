namespace PageObjectModels
{
    public class PagesConfigReader : ConfigReader
    {
        public static string BaseUrl = configObj.BaseUrl;

        public static string DispatchesPage = BaseUrl + configObj.pages.Dispatches;
        public static string PollsPage = BaseUrl + configObj.pages.Polls;
        public static string ResultsPage = BaseUrl + configObj.pages.Results;

        public static string DispatchesUrl = BaseUrl + DispatchesPage;
        public static string PollsUrl = BaseUrl + PollsPage;
        public static string ResultsUrl = BaseUrl + ResultsPage;
    }
}