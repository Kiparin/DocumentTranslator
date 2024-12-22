using Novacode;

using Reader.Intarfaces.BaseAbstract;

using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace Reader.Services
{
    public class PDFReader : DocumentBase, IDisposable
    {
        private Dictionary<int, string> _pages = new Dictionary<int, string>();

        public Dictionary<int, string> TranslatedPage { get; set; } = new Dictionary<int, string>();

        public PDFReader()
        {
            Id = "PDF";
        }

        public override int Count() => _pages.Count;

        public override Dictionary<int, string> GetPages() => _pages;

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

        public void Save(string nameFile)
        {
            using (var doc = DocX.Create(nameFile + ".docx"))
            {
                foreach (var page in TranslatedPage)
                {
                    if (page.Value != null)
                    {
                        var p = doc.InsertParagraph();
                        p.Append(page.Value);
                    }
                }
                doc.Save();
            }
        }

        public void Dispose()
        {
            if (_pages != null)
            {
                _pages.Clear();
                TranslatedPage.Clear();
            }

            GC.SuppressFinalize(this);
        }
    }
}