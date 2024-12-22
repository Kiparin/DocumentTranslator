namespace Reader.Intarfaces
{
    public interface IDocument
    {
        public void Read(string path);

        public void Save(string path, string text);

        public int Count();

        public Dictionary<int, string> GetPages();
    }
}