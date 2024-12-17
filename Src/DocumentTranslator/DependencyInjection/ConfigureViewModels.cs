using DocumentTranslator.ViewModel;

using Microsoft.Extensions.DependencyInjection;

namespace DocumentTranslator.DependencyInjection
{
    internal class ConfigureViewModels
    {
        internal static void Configure(ServiceCollection services)
        {
            services.AddTransient<DocumentTranslatorAIViewModel>();
        }
    }
}
