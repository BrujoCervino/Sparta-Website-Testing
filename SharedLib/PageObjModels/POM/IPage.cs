namespace PageObjectModels
{
    public interface IPage
    {
        void Visit();
        void MaximisePage();
        string GetCurrentUrl();
        string GetPageTitle();
        void ClickLogo();
        void ClickTitle();
    }
}