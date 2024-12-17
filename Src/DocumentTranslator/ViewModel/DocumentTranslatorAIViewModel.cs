
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

using DocumentTranslator.Helpers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

using Model.Enums;
using Model.Model;

namespace DocumentTranslator.ViewModel
{
    public class DocumentTranslatorAIViewModel
    {
        public ObservableCollection<LanguageItem> LanguagesItems { get; set; }

        public NotifyProperty<object> SelectLanguages { get; set; } = new NotifyProperty<object>(new object());

        public NotifyProperty<string> Percent { get; set; } = new NotifyProperty<string>("");

        public NotifyProperty<string> Path { get; set; } = new NotifyProperty<string>("");

        public ICommand OpenFileCommand { get; set; }

        public ICommand RunCommand { get; set; }


        public DocumentTranslatorAIViewModel()
        {
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
            
        }
    }
}
