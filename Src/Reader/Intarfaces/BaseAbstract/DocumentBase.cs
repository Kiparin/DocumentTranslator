namespace Reader.Intarfaces.BaseAbstract
{
    public abstract class DocumentBase : IDocument
    {
        public string Id { get; set; }

        public abstract int Count();

        public abstract Dictionary<int, string> GetPages();

        public abstract void Read(string path);

        public void Save(string path, string text)
        {
            // реализовать сохранение в файл с возможностью добавления
        }
    }
}