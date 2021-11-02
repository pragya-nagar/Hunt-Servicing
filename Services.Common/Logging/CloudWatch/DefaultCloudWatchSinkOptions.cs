using Serilog.Sinks.AwsCloudWatch;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Services.Common.Logging.CloudWatch
{
    [ExcludeFromCodeCoverage]
    public class DefaultCloudWatchSinkOptions : CloudWatchSinkOptions
    {
        public DefaultCloudWatchSinkOptions(string logGroupName)
        {
            if (string.IsNullOrWhiteSpace(logGroupName))
            {
                throw new ArgumentNullException(nameof(logGroupName));
            }

            TextFormatter = new CloudWatchCompactJsonFormatter();
            CreateLogGroup = true;
            Period = TimeSpan.FromSeconds(30);
            LogGroupName = logGroupName;
        }
    }
}
