using Api;

using DocumentTranslator.Services;

using Microsoft.Extensions.DependencyInjection;

using Reader.Services;

namespace DocumentTranslator.DependencyInjection
{
    internal class ConfigureServices
    {
        internal static void Configure(ServiceCollection services)
        {
            services.AddTransient<PDFReader>();
            services.AddTransient<Translator>();
            services.AddTransient<ApiService>();
        }
    }
}
