
using System.Collections.ObjectModel;
using System.Windows.Input;

using DocumentTranslator.Helpers;
using DocumentTranslator.Services;

using Microsoft.Win32;

using Model.Enums;
using Model.Model;

namespace DocumentTranslator.ViewModel
{
    public class DocumentTranslatorAIViewModel
    {
        private Translator _translator;

        public ObservableCollection<LanguageItem> LanguagesItems { get; set; }

        public NotifyProperty<object> SelectLanguages { get; set; } = new NotifyProperty<object>(new object());

        public NotifyProperty<string> Percent { get; set; } = new NotifyProperty<string>("");

        public NotifyProperty<string> Path { get; set; } = new NotifyProperty<string>("");

        public ICommand OpenFileCommand { get; set; }

        public ICommand RunCommand { get; set; }



        public DocumentTranslatorAIViewModel(Translator translator)
        {
            _translator = translator;

            LanguagesItems = new ObservableCollection<LanguageItem>
            {
                new LanguageItem { Id = 1, Languages = Languages.Русский },
                new LanguageItem { Id = 2, Languages = Languages.English }
            };

            OpenFileCommand = new RelayCommand(OpenFile);
            RunCommand = new AsyncRelayCommand(Run);
        }

        private void OpenFile(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Select a PDF file",
                Multiselect = false 
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Path.Value = openFileDialog.FileName;
            }
        }

        private async Task Run(object? parameter)
        {
            var item = (LanguageItem)SelectLanguages.Value;
            _translator.OnNotify += Notify;
            await _translator.Tranlate(Path.Value, item.Id);
        }

        private async Task Notify(string message)
        {
            Percent.Value = message;
        }
    }
}
