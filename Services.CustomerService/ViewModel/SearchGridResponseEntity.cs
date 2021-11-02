using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// SearchGridResponseEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SearchGridResponseEntity
    {
        /// <summary>
        /// NumberOfLienCountActive
        /// </summary>
        public int NumberOfLienCountActive { get; set; }
        /// <summary>
        /// NumberOfLienCountRedeemed
        /// </summary>
        public int NumberOfLienCountRedeemed { get; set; }
        /// <summary>
        /// OriAssetId
        /// </summary>
        public string OriAssetId { get; set; }
        /// <summary>
        /// Jurisdiction
        /// </summary>
        public string Jurisdiction { get; set; }
        /// <summary>
        /// OwnerName
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// PropertyAddress
        /// </summary>
        public string PropertyAddress { get; set; }
        /// <summary>
        /// StateName
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// ParcelID
        /// </summary>
        public string ParcelID { get; set; }
        /// <summary>
        /// TotalDue
        /// </summary>
        public string TotalDue { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public string AssetId { get; set; }
        /// <summary>
        /// AssetStatus
        /// </summary>
        public string AssetStatus { get; set; }
    }
}
