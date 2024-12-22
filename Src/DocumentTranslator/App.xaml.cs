using System.Windows;

using DocumentTranslator.DependencyInjection;
using DocumentTranslator.Views;

using Microsoft.Extensions.DependencyInjection;

namespace DocumentTranslator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public ServiceProvider ServiceProvider => _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureDependencyInjection.Configure(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}