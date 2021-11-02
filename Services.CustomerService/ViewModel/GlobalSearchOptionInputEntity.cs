using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// GlobalSearchOptionInputEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GlobalSearchOptionInputEntity : BaseEntity
    {
        /// <summary>
        /// OriAssetId
        /// </summary>
        [JsonProperty(PropertyName = "Ori Asset ID")]
        [DisplayName("Ori Asset ID")]
        public string OriAssetId { get; set; }
        /// <summary>
        /// ParcelID
        /// </summary>
        [JsonProperty(PropertyName = "Parcel ID")]
        [DisplayName("Parcel ID")]
        public string ParcelID { get; set; }
        /// <summary>
        /// AlternativeParcelID1
        /// </summary>
        [JsonProperty(PropertyName = "Alternative Parcel ID 1")]
        [DisplayName("Alternative Parcel ID 1")]
        public string AlternativeParcelID1 { get; set; }
        /// <summary>
        /// AlternativeParcelID2
        /// </summary>
        [JsonProperty(PropertyName = "Alternative Parcel ID 2")]
        [DisplayName("Alternative Parcel ID 2")]
        public string AlternativeParcelID2 { get; set; }
        /// <summary>
        /// AlternativeParcelID3
        /// </summary>
        [JsonProperty(PropertyName = "Alternative Parcel ID 3")]
        [DisplayName("Alternative Parcel ID 3")]
        public string AlternativeParcelID3 { get; set; }
        /// <summary>
        /// PropertyAddress
        /// </summary>
        [JsonProperty(PropertyName = "Property Address")]
        [DisplayName("Property Address")]
        public string PropertyAddress { get; set; }
        /// <summary>
        /// OwnerName
        /// </summary>
        [JsonProperty(PropertyName = "Owner Name")]
        [DisplayName("Owner Name")]
        public string OwnerName { get; set; }
        /// <summary>
        /// OwnerAddress
        /// </summary>
        [JsonProperty(PropertyName = "Owner Address")]
        [DisplayName("Owner Address")]
        public string OwnerAddress { get; set; }
        /// <summary>
        /// CertNo
        /// </summary>
        [JsonProperty(PropertyName = "Cert")]
        [DisplayName("Cert")]
        public string CertNo { get; set; }
    }
}
