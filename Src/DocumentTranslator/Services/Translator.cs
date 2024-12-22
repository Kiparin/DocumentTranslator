
using System.IO;

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
                await OnNotify?.Invoke("Translate " + item.Key + " page in " + _pdfReade.GetPages().Count);
                var result = await _api.SendAsync(item.Value);
                if (result != null) 
                {
                    var choice = result.Choices.FirstOrDefault();
                    _pdfReade.TranslatedPage.Add(item.Key, choice?.Message.Content ?? "");
                }
            }

            if(_pdfReade.TranslatedPage.Count != 0)
            {
                await OnNotify?.Invoke("Save to dock");
                _pdfReade.Save(Path.GetFileName(path));
            }

            await OnNotify?.Invoke("Cleare");
            _pdfReade.Dispose();
        }
    }
}
