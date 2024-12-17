using DocumentTranslator.Views;

using Microsoft.Extensions.DependencyInjection;

namespace DocumentTranslator.DependencyInjection
{
    internal class ConfigurePage
    {
        internal static void Configure(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
        }
    }
}
