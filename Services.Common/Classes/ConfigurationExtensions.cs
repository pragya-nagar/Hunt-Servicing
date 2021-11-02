using Amazon;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Services.Common.Classes
{
    /// <summary>
    /// ConfigurationExtensions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// UseDefaultSettings
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseDefaultSettings(this IWebHostBuilder builder)
        {
            string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            builder
                .UseEnvironment(environmentName)
                .ConfigureAppConfiguration((a, b) => a.ConfigureAppConfiguration(b));
            return builder;
        }
        /// <summary>
        /// ConfigureAppConfiguration
        /// </summary>
        /// <param name="hostingContext"></param>
        /// <param name="builder"></param>
        public static void ConfigureAppConfiguration(this WebHostBuilderContext hostingContext, IConfigurationBuilder builder)
        {
            if (!hostingContext.HostingEnvironment.IsDevelopment())
            {
                builder.AddSystemsManager(configureSource =>
                {
                    var env = hostingContext.HostingEnvironment;

                    // Parameter Store prefix to pull configuration data from.
                    configureSource.Path = $"/hunt-caz-creek-synergy/{env.EnvironmentName}";

                    // Reload configuration data every 15 minutes.
                    configureSource.ReloadAfter = TimeSpan.FromMinutes(15);
                });
            }
        }
        /// <summary>
        /// GetRegionEndPoint
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static RegionEndpoint GetRegionEndPoint(this IConfiguration configuration)
        {
            var region = RegionEndpoint.GetBySystemName(configuration["AWS:Region"]);

            if (Equals(region.DisplayName, "Unknown"))
            {
                region = RegionEndpoint.USEast1;
            }

            return region;
        }
    }
}
