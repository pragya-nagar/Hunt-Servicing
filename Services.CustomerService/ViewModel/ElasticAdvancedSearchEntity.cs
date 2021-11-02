using System.Diagnostics.CodeAnalysis;
using Nest;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// ElasticAdvancedSearch Entity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ElasticAdvancedSearchEntity
    {
        /// <summary>
        /// Gets or sets the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        [Text(Name = "asset-assetid", Fielddata = true)]
        public string AssetId { get; set; }
        /// <summary>
        /// Gets or sets the number of lien count active.
        /// </summary>
        /// <value>
        /// The number of lien count active.
        /// </value>
        [Text(Name = "lien-activecount")]
        public int NumberOfLienCountActive { get; set; }
        /// <summary>
        /// Gets or sets the number of lien count redeemed.
        /// </summary>
        /// <value>
        /// The number of lien count redeemed.
        /// </value>
        [Text(Name = "lien-redeemedcount")]
        public int NumberOfLienCountRedeemed { get; set; }
        /// <summary>
        /// Get the ori asset identifier.
        /// </summary>
        /// <value>
        /// The ori asset identifier.
        /// </value>
        [Text(Name = "asset-oriassetid")]
        public string OriAssetId { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction.
        /// </summary>
        /// <value>
        /// The jurisdiction.
        /// </value>
        [Text(Name = "asset-jurisdiction")]
        public string Jurisdiction { get; set; }
        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        [Text(Name = "owner-ownername")]
        public string OwnerName { get; set; }
        /// <summary>
        /// Gets or sets the property address.
        /// </summary>
        /// <value>
        /// The property address.
        /// </value>
        [Text(Name = "property-propertyaddress")]
        public string PropertyAddress { get; set; }
        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>
        /// The name of the state.
        /// </value>
        [Text(Name = "asset-statename")]
        public string StateName { get; set; }
        /// <summary>
        /// Gets or sets the parcel identifier.
        /// </summary>
        /// <value>
        /// The parcel identifier.
        /// </value>
        [Text(Name = "property-parcelid")]
        public string ParcelId { get; set; }
        /// <summary>
        /// Gets or sets the total due.
        /// </summary>
        /// <value>
        /// The total due.
        /// </value>
        [Text(Name = "asset-totaldue")]
        public int TotalDue { get; set; }  
    }
}
