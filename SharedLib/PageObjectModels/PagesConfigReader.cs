namespace PageObjectModels
{
    public class PagesConfigReader : ConfigReader
    {
        public static string BaseUrl = GetRoot().BaseUrl;

        public static string DispatchesPage = GetRoot().pages.Dispatches;
        public static string PollsPage = GetRoot().pages.Polls;
        public static string ResultsPage = GetRoot().pages.Results;

        public static string DispatchesUrl = BaseUrl + DispatchesPage;
        public static string PollsUrl = BaseUrl + PollsPage;
        public static string ResultsUrl = BaseUrl + ResultsPage;
    }
}