using System.Xml;

using Reader.Intarfaces.BaseAbstract;

using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace Reader.Services
{
    public class PDFReader : DocumentBase, IDisposable
    {
        private Dictionary<int,string> _pages = new Dictionary<int,string>();

        public PDFReader() 
        {
            Id = "PDF";
        }

        public override int Count() => _pages.Count;

        public override string GetPage(int page) => _pages[page];

        public override void Read(string path)
        {
            using (var pdf = PdfDocument.Open(path))
            {
                var iteratop = 1;
                foreach (var page in pdf.GetPages())
                {
                    var text = ContentOrderTextExtractor.GetText(page);
                    _pages[iteratop] = text;
                    iteratop++;
                }

            }
        }

        public void Save()
        {

        }

        public void Dispose()
        {
            if (_pages != null)
            {
                _pages.Clear();
            }

            GC.SuppressFinalize(this);
        }
    }
}
