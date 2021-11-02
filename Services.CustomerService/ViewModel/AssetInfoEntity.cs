using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// AssetInfoEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AssetInfoEntity : BaseEntity
    {
        /// <summary>
        /// AssetName
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// PropertyAddress
        /// </summary>
        public string PropertyAddress { get; set; }
        /// <summary>
        /// PropertyType
        /// </summary>
        public string PropertyType { get; set; }
    }
}
