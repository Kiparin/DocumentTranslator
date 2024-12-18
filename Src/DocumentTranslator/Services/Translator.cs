
using Api;

using Model.Interfaces;

using Reader.Services;

namespace DocumentTranslator.Services
{
    public class Translator : ITranslator
    {
        public delegate Task Notify(string message);
        public event Notify OnNotify;

        private PDFReader _pdfReade;
        private ApiService _api;

        public Translator(PDFReader pDFReader, ApiService api) 
        { 
            _pdfReade = pDFReader;
            _api = api;
        }

        public async Task Tranlate(string path, int idTranslate)
        {
            switch (idTranslate)
            {
                case 1:
                    await RussianTranslate(path);
                    break;
                case 2:
                    break;
            }
        }

        private async Task RussianTranslate(string path)
        {
            await OnNotify?.Invoke("Open PDF");
            _pdfReade.Read(path);

            foreach (var item in _pdfReade.GetPages())
            {
                var result = await _api.SendAsync(item.Value);
                if (result != null) 
                { 

                }
            }
            
        }
    }
}
