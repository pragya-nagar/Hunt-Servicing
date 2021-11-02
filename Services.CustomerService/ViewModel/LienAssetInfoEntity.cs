using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// LienAssetInfoEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LienAssetInfoEntity
    {
        /// <summary>
        /// AssetId
        /// </summary>
        public string AssetId { get; set; }
        /// <summary>
        /// LienHierarchy
        /// </summary>
        public string LienHierarchy { get; set; }
        /// <summary>
        /// Jurisdiction
        /// </summary>
        public string Jurisdiction { get; set; }
        /// <summary>
        /// OriAssetId
        /// </summary>
        public string OriAssetId { get; set; }
        /// <summary>
        /// Cert
        /// </summary>
        public string CertNo { get; set; }
        /// <summary>
        /// AlternativeId
        /// </summary>
        public string AlternativeId { get; set; }
        /// <summary>
        /// PurchasingEntity
        /// </summary>
        public string PurchasingEntity { get; set; }
        /// <summary>
        /// AcquisitionDate
        /// </summary>
        public string AcquisitionDate { get; set; }
        /// <summary>
        /// RedemptionDate
        /// </summary>
        public string RedemptionDate { get; set; }
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
        /// TaxYear
        /// </summary>
        public int TaxYear { get; set; }
        /// <summary>
        /// AssetStatus
        /// </summary>
        public string AssetStatus { get; set; }
        /// <summary>
        /// AssetLegalStatus
        /// </summary>
        public string AssetLegalStatus { get; set; }
    }
}
