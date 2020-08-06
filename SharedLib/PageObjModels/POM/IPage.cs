namespace PageObjModels
{
    public interface IPage
    {
        void Visit();
        void MaximisePage();
        string GetCurrentUrl();
    }
}