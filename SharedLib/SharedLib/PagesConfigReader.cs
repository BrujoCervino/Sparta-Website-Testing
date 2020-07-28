namespace SharedLib
{
    public class PagesConfigReader : ConfigReader
    {
        public static readonly string BaseUrl = configObj.BaseUrl;

        public static readonly string DispatchesPage = configObj.pages.Dispatches;
        public static readonly string PollsPage = configObj.pages.Polls;
        public static readonly string ResultsPage = configObj.pages.Results;

        public static readonly string DispatchesUrl = BaseUrl + DispatchesPage;
        public static readonly string PollsUrl = BaseUrl + PollsPage;
        public static readonly string ResultsUrl = BaseUrl + ResultsPage; 
    }
}