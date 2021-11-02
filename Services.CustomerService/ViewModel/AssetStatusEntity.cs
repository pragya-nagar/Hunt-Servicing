using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// AssetStatusEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AssetStatusEntity
    {
        /// <summary>
        /// StatusName
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// StatusCode
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// StatusId
        /// </summary>
        public int StatusId { get; set; }
    }
}
