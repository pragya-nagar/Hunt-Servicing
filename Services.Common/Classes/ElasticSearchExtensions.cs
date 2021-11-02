using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Services.Common.Constants;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Services.Common.Classes
{
    [ExcludeFromCodeCoverage]
    public static class ElasticSearchExtensions
    {
        /// <summary>
        /// Configures the elastic search.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>       
        public static void ConfigureElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            ConnectionSettings settings = null;
            try
            {
                var url = configuration[AppSettingConstants.ElsConfigUrl] ?? string.Empty;
                if (!string.IsNullOrEmpty(url))
                {
                    settings = new ConnectionSettings(new Uri(url))
                        .DisableDirectStreaming()
                        .DefaultIndex(AppSettingConstants.ElsConfigGlobalIndex);
                }

                var client = new ElasticClient(settings);
                services.AddSingleton<IElasticClient>(client);
            }
            finally
            {
                // How to release resources?
                ((IDisposable)settings)?.Dispose();
            }
        }
    }
}
