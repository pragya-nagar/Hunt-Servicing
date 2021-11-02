using Nest;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Services.ElasticSearch.Entity
{
    /// <summary>
    /// ElasticGlobalSearch Entity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ElasticGlobalSearchEntity
    {
        /// <summary>
        /// Get the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        [Text(Name = "asset-assetid", Fielddata = true)]
        public string AssetId { get; set; }
        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>
        /// The state identifier.
        /// </value>
        [Text(Name = "asset-stateid")]
        public int StateId { get; set; }
        /// <summary>
        /// Get the ori asset identifier.
        /// </summary>
        /// <value>
        /// The ori asset identifier.
        /// </value>
        [Text(Name = "asset-oriassetid")]
        public string OriAssetId { get; set; }
        /// <summary>
        /// Get the cert no.
        /// </summary>
        /// <value>
        /// The cert no.
        /// </value>
        [Text(Name = "asset-certno")]
        public string CertNo { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        [Text(Name = "asset-createddate", Fielddata = true)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the parcel identifier.
        /// </summary>
        /// <value>
        /// The parcel identifier.
        /// </value>
        [Text(Name = "property-parcelid")]
        public string ParcelId { get; set; }
        /// <summary>
        /// Gets or sets the alternative parcel id1.
        /// </summary>
        /// <value>
        /// The alternative parcel id1.
        /// </value>
        [Text(Name = "property-alternativeparcelid1")]
        public string AlternativeParcelId1 { get; set; }
        /// <summary>
        /// Gets or sets the alternative parcel id2.
        /// </summary>
        /// <value>
        /// The alternative parcel id2.
        /// </value>
        [Text(Name = "property-alternativeparcelid2")]
        public string AlternativeParcelId2 { get; set; }
        /// <summary>
        /// Gets or sets the alternative parcel id3.
        /// </summary>
        /// <value>
        /// The alternative parcel id3.
        /// </value>
        [Text(Name = "property-alternativeparcelid3")]
        public string AlternativeParcelId3 { get; set; }
        /// <summary>
        /// Gets or sets the property address.
        /// </summary>
        /// <value>
        /// The property address.
        /// </value>
        [Text(Name = "property-propertyaddress")]
        public string PropertyAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        [Text(Name = "owner-ownername")]
        public string OwnerName { get; set; }
        /// <summary>
        /// Gets or sets the owner address.
        /// </summary>
        /// <value>
        /// The owner address.
        /// </value>
        [Text(Name = "owner-owneraddress")]
        public string OwnerAddress { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Text(Name = "contact-firstname")]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Text(Name = "contact-lastname")]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [Text(Name = "contact-contactname")]
        public string ContactName { get; set; }
        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        /// <value>
        /// The cell phone.
        /// </value>
        [Text(Name = "contact-cellphone")]
        public string CellPhone { get; set; }
    }
}
