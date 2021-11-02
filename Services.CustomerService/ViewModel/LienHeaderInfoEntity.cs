using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// LienHeaderInfoEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LienHeaderInfoEntity
    {
        /// <summary>
        /// AssetName
        /// </summary>
        public IEnumerable<string> AssetName { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public string AssetId { get; set; }
        /// <summary>
        /// PropertyAddress
        /// </summary>
        public IEnumerable<string> PropertyAddress { get; set; }
        /// <summary>
        /// PropertyTypeName
        /// </summary>
        public string PropertyTypeName { get; set; }
    }
    /// <summary>
    /// LienHeaderInfoEntityResponse
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LienHeaderInfoEntityResponse
    {
        /// <summary>
        /// AssetName
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public string AssetId { get; set; }
        /// <summary>
        /// PropertyAddress
        /// </summary>
        public string PropertyAddress { get; set; }
        /// <summary>
        /// PropertyTypeName
        /// </summary>
        public string PropertyTypeName { get; set; }
    }
}
