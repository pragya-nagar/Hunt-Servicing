using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Services.Common.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Services.Common.Classes
{
    /// <summary>
    /// AppBuilderExtensions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// UseVersion
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseVersion(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            app.Map("/api/version", builder =>
            {
                builder.Run(async context =>
                {
                    var runtimeContext = context.RequestServices.GetRequiredService<IRunTimeContext>();
                    context.Response.ContentType = "application/json";
                    var responseBody = JsonConvert.SerializeObject(new
                    {
                        runtimeContext.Version,
                        Uptime = runtimeContext.Uptime.ToString(@"dd\.hh\:mm\:ss", CultureInfo.InvariantCulture),
                    });

                    await context.Response.WriteAsync(responseBody);
                });
            });
            return app;

        }
        /// <summary>
        /// AddRunTimeContext
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRunTimeContext(this IServiceCollection services)
        {
            services.TryAddSingleton<IRunTimeContext, RunTimeContext>();

            return services;
        }
    }
}
