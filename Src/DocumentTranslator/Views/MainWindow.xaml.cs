using System.Windows;

using DocumentTranslator.ViewModel;

namespace DocumentTranslator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DocumentTranslatorAIViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}