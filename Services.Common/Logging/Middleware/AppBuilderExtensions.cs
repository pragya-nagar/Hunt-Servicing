using System.Diagnostics.CodeAnalysis;
using CorrelationId;
using Microsoft.AspNetCore.Builder;

namespace Services.Common.Logging.Middleware
{
    [ExcludeFromCodeCoverage]
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCorrelationLogging(this IApplicationBuilder app)
        {
            app.UseCorrelationId(new CorrelationIdOptions
            {
                Header = "X-Correlation-ID",
                UseGuidForCorrelationId = true,
                UpdateTraceIdentifier = false,
            });

            app.UseMiddleware<LogEnricherMiddleware>();

            return app;
        }
    }
}
