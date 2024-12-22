
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

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
            try
            {
                var item = (LanguageItem)SelectLanguages.Value;
                if (String.IsNullOrEmpty(Path.Value))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _translator.OnNotify += Notify;
                    await _translator.Tranlate(Path.Value, item.Id);
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("You have not selected the language you will be translating to.", null, MessageBoxButton.OK);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("File not found.", null, MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something strange happened.\n" + ex.Message, null, MessageBoxButton.OK);
            }
        }

        private async Task Notify(string message)
        {
            await Task.Run(() =>
            {
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    Percent.Value = message;
                });
            });
        }
    }
}
