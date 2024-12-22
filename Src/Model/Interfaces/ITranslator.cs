namespace Model.Interfaces
{
    public interface ITranslator
    {
        Task Tranlate(string path, int idTranslate);
    }
}