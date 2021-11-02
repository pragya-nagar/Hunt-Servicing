using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Serilog.Events;

namespace Services.Common.Logging.CloudWatch
{
    [ExcludeFromCodeCoverage]
    public class SinksConfiguration
    {
        public CloudWatchConfiguration CloudWatch { get; set; }

        public LogEventLevel? MinimumLevel { get; set; }

        public Dictionary<string, LogEventLevel> LevelOverride { get; set; }
    }
}
