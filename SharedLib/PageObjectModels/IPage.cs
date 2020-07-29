namespace PageObjectModels
{
    public interface IPage
    {
        void Visit();
        void MaximisePage();
        string GetCurrentUrl();
    }
}