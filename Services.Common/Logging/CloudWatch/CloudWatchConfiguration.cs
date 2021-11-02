using System.Diagnostics.CodeAnalysis;

namespace Services.Common.Logging.CloudWatch
{
    [ExcludeFromCodeCoverage]
    public class CloudWatchConfiguration
    {
        public string Region { get; set; }
        public string LogGroupName { get; set; }
    }
}
