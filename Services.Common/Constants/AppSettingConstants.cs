
using System.Diagnostics.CodeAnalysis;

namespace Services.Common.Constants
{
    /// <summary>
    /// This class used to app settings variable information.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class AppSettingConstants
    {
        /// <summary>
        /// The connection name
        /// </summary>
        public static readonly string ConnName = "CUSTSVC";
        // <summary>
        /// <summary>
        /// The els configuration URL
        /// </summary>
        public const string ElsConfigUrl = "AWSESUrl";
        /// <summary>
        /// Global index
        /// </summary>
        public const string ElsConfigGlobalIndex = "customer-service-auto-suggest-search";
        /// <summary>
        /// Advance index
        /// </summary>
        public const string ElsConfigAdvanceIndex = "customer-service-advance-suggest-search";
        /// <summary>
        /// S3FolderPath
        /// </summary>
        public const string S3FolderPath = "HuntServicing/";
        /// <summary>
        /// The s3 folder name
        /// </summary>
        public const string S3FolderName = "HuntServicing";
    }
}
