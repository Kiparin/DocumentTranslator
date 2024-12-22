using Microsoft.Extensions.DependencyInjection;

namespace DocumentTranslator.DependencyInjection
{
    internal class ConfigureDependencyInjection
    {
        internal static void Configure(ServiceCollection services)
        {
            ConfigurePage.Configure(services);
            ConfigureViewModels.Configure(services);
            ConfigureServices.Configure(services);
        }
    }
}