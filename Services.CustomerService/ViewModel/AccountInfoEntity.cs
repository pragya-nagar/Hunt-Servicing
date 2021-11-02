using System;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// AccountInfoEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AccountInfoEntity : BaseEntity
    {
        /// <summary>
        /// LienHierarchy
        /// </summary>
        public int LienHierarchy { get; set; }
        /// <summary>
        /// Jurisdiction
        /// </summary>
        public string Jurisdiction { get; set; }
        /// <summary>
        /// OriAssetID
        /// </summary>
        public string OriAssetID { get; set; }
        /// <summary>
        /// Cert
        /// </summary>
        public string Cert { get; set; }
        /// <summary>
        /// AlternativeID
        /// </summary>
        public string AlternativeID { get; set; }
        /// <summary>
        /// PurchasingEntity
        /// </summary>
        public string PurchasingEntity { get; set; }
        /// <summary>
        /// AcquisitionDate
        /// </summary>
        public DateTime AcquisitionDate { get; set; }
        /// <summary>
        /// RedemptionDate
        /// </summary>
        public DateTime RedemptionDate { get; set; }
        /// <summary>
        /// FinancingGroup
        /// </summary>
        public string FinancingGroup { get; set; }
        /// <summary>
        /// CurrentEntity
        /// </summary>
        public string CurrentEntity { get; set; }
        /// <summary>
        /// LandUseCode
        /// </summary>
        public string LandUseCode { get; set; }
        /// <summary>
        /// AttorneyName
        /// </summary>
        public string AttorneyName { get; set; }
        /// <summary>
        /// Custodian
        /// </summary>
        public string Custodian { get; set; }
        /// <summary>
        /// TaxYear
        /// </summary>
        public int TaxYear { get; set; }
        /// <summary>
        /// AssetStatus
        /// </summary>
        public int AssetStatus { get; set; }
        /// <summary>
        /// AssetLegalStatus
        /// </summary>
        public int AssetLegalStatus { get; set; }
    }
}
