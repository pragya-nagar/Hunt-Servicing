using Nest;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Services.ElasticSearch.Entity
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
        /// Get the ori asset identifier.
        /// </summary>
        /// <value>
        /// The ori asset identifier.
        /// </value>
        [Text(Name = "asset-oriassetid")]
        public string OriAssetId { get; set; }
        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        [Text(Name = "owner-ownername")]
        public string OwnerName { get; set; }
        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>
        /// The state identifier.
        /// </value>
        [Text(Name = "asset-stateid")]
        public int StateId { get; set; }
        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>
        /// The name of the state.
        /// </value>
        [Text(Name = "asset-statename")]
        public string StateName { get; set; }
        /// <summary>
        /// Gets or sets the cert no.
        /// </summary>
        /// <value>
        /// The cert no.
        /// </value>
        [Text(Name = "asset-certno")]
        public string CertNo { get; set; }
        /// <summary>
        /// Gets or sets the name of the attorney.
        /// </summary>
        /// <value>
        /// The name of the attorney.
        /// </value>
        [Text(Name = "asset-attorneyname")]
        public string AttorneyName { get; set; }
        /// <summary>
        /// Gets or sets the alternative identifier.
        /// </summary>
        /// <value>
        /// The alternative identifier.
        /// </value>
        [Text(Name = "asset-alternativeid")]
        public string AlternativeId { get; set; }
        /// <summary>
        /// Gets or sets the asset status.
        /// </summary>
        /// <value>
        /// The asset status.
        /// </value>
        [Text(Name = "asset-assetstatus")]
        public int AssetStatus { get; set; }
        /// <summary>
        /// Gets or sets the jurisdiction.
        /// </summary>
        /// <value>
        /// The jurisdiction.
        /// </value>
        [Text(Name = "asset-jurisdiction")]
        public string Jurisdiction { get; set; }
        /// <summary>
        /// Gets or sets the lien hierarchy.
        /// </summary>
        /// <value>
        /// The lien hierarchy.
        /// </value>
        [Text(Name = "asset-lienhierarchy")]
        public string LienHierarchy { get; set; }
        /// <summary>
        /// Gets or sets the total due.
        /// </summary>
        /// <value>
        /// The total due.
        /// </value>
        [Text(Name = "asset-totaldue")]
        public int TotalDue { get; set; }
        /// <summary>
        /// Gets or sets the acquisition date.
        /// </summary>
        /// <value>
        /// The acquisition date.
        /// </value>
        [Text(Name = "asset-acquisitiondate")]
        public DateTime AcquisitionDate { get; set; }

        /// <summary>
        /// Gets or sets the purchasing entity.
        /// </summary>
        /// <value>
        /// The purchasing entity.
        /// </value>
        [Text(Name = "asset-purchasingentity")]
        public string PurchasingEntity { get; set; }
        /// <summary>
        /// Gets or sets the current entity.
        /// </summary>
        /// <value>
        /// The current entity.
        /// </value>
        [Text(Name = "asset-currententity")]
        public string CurrentEntity { get; set; }
        /// <summary>
        /// Gets or sets the financing group.
        /// </summary>
        /// <value>
        /// The financing group.
        /// </value>
        [Text(Name = "asset-financinggroup")]
        public string FinancingGroup { get; set; }

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
        /// Gets or sets the parcel identifier.
        /// </summary>
        /// <value>
        /// The parcel identifier.
        /// </value>
        [Text(Name = "property-parcelid")]
        public string ParcelId { get; set; }       
        /// <summary>
        /// Gets or sets the alternate parcel id1.
        /// </summary>
        /// <value>
        /// The alternate parcel id1.
        /// </value>
        [Text(Name = "property-alternativeparcelid1")]
        public string AlternateParcelId1 { get; set; }
        /// <summary>
        /// Gets or sets the alternate parcel id2.
        /// </summary>
        /// <value>
        /// The alternate parcel id2.
        /// </value>
        [Text(Name = "property-alternativeparcelid2")]
        public string AlternateParcelId2 { get; set; }
        /// <summary>
        /// Gets or sets the alternate parcel id3.
        /// </summary>
        /// <value>
        /// The alternate parcel id3.
        /// </value>
        [Text(Name = "property-alternativeparcelid3")]
        public string AlternateParcelId3 { get; set; }
        /// <summary>
        /// Gets or sets the property address.
        /// </summary>
        /// <value>
        /// The property address.
        /// </value>
        [Text(Name = "property-propertyaddress")]
        public string PropertyAddress { get; set; }
    }
}
