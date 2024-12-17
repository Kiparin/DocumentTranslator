using Microsoft.Extensions.DependencyInjection;

using Reader.Intarfaces;
using Reader.Services;

namespace DocumentTranslator.DependencyInjection
{
    internal class ConfigureServices
    {
        internal static void Configure(ServiceCollection services)
        {
            services.AddSingleton<IDocument, PDFReader>();
        }
    }
}
