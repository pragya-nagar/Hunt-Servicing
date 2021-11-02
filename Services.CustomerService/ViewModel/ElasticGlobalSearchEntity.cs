using System.Diagnostics.CodeAnalysis;
using Nest;
using Newtonsoft.Json;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// GlobalSearchElasticSearch Entity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ElasticGlobalSearchEntity
    {
        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        /// <value>
        /// The cell phone.
        /// </value>
        [Text(Name = "contact-cellphone")]
        [JsonProperty(PropertyName = "Phone Number")]
        public string CellPhone { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [Text(Name = "contact-fullname")]
        [JsonProperty(PropertyName = "Contact Name")]
        public string ContactName { get; set; }

        /// <summary>
        /// Get the ori asset identifier.
        /// </summary>
        /// <value>
        /// The ori asset identifier.
        /// </value>
        [Text(Name = "asset-oriassetid")]
        [JsonProperty(PropertyName = "Ori Asset ID")]
        public string OriAssetId { get; set; }

        /// <summary>
        /// Gets or sets the parcel identifier.
        /// </summary>
        /// <value>
        /// The parcel identifier.
        /// </value>
        [Text(Name = "property-parcelid")]
        [JsonProperty(PropertyName = "Parcel ID")]
        public string ParcelId { get; set; }

        /// <summary>
        /// Gets or sets the alternative parcel id1.
        /// </summary>
        /// <value>
        /// The alternative parcel id1.
        /// </value>
        [Text(Name = "property-alternativeparcelid1")]
        [JsonProperty(PropertyName = "Alternative Parcel ID 1")]
        public string AlternativeParcelId1 { get; set; }
        /// <summary>
        /// Gets or sets the alternative parcel id2.
        /// </summary>
        /// <value>
        /// The alternative parcel id2.
        /// </value>
        [Text(Name = "property-alternativeparcelid2")]
        [JsonProperty(PropertyName = "Alternative Parcel ID 2")]
        public string AlternativeParcelId2 { get; set; }
        /// <summary>
        /// Gets or sets the alternative parcel id3.
        /// </summary>
        /// <value>
        /// The alternative parcel id3.
        /// </value>
        [Text(Name = "property-alternativeparcelid3")]
        [JsonProperty(PropertyName = "Alternative Parcel ID 3")]
        public string AlternativeParcelId3 { get; set; }

        /// <summary>
        /// Gets or sets the name of the owner-
        /// </summary>
        /// <value>
        /// The name of the owner-
        /// </value>
        [Text(Name = "owner-ownername")]
        [JsonProperty(PropertyName = "Owner Name")]
        public string OwnerName { get; set; }
        /// <summary>
        /// Gets or sets the owner address.
        /// </summary>
        /// <value>
        /// The owner address.
        /// </value>
        [Text(Name = "owner-owneraddress")]
        [JsonProperty(PropertyName = "Owner Address")]
        public string OwnerAddress { get; set; }

        /// <summary>
        /// Get the cert no.
        /// </summary>
        /// <value>
        /// The cert no.
        /// </value>
        [Text(Name = "asset-certno")]
        [JsonProperty(PropertyName = "Cert")]
        public string CertNo { get; set; }

        /// <summary>
        /// Get the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        [Text(Name = "asset-assetid", Fielddata = true)]
        [JsonProperty(PropertyName = "Asset ID")]
        public string AssetId { get; set; }
    }
}
