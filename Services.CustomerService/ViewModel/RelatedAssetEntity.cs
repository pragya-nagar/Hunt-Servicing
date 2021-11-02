using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// RelatedAssetEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RelatedAssetEntity
    {
        /// <summary>
        /// AssetId
        /// </summary>
        public string AssetId { get; set; }
        /// <summary>
        /// OriAssetId
        /// </summary>
        public string OriAssetId { get; set; }
        /// <summary>
        /// CertNo
        /// </summary>
        public string CertNo { get; set; }
        /// <summary>
        /// LienHierarchy
        /// </summary>
        public string LienHierarchy { get; set; }
        /// <summary>
        /// AcquisitionDate
        /// </summary>
        public string AcquisitionDate { get; set; }
        /// <summary>
        /// CurrentEntity
        /// </summary>
        public string CurrentEntity { get; set; }
        /// <summary>
        /// FinancingGroup
        /// </summary>
        public string FinancingGroup { get; set; }
        /// <summary>
        /// AssetStatus
        /// </summary>
        public string AssetStatus { get; set; }
        /// <summary>
        /// TaxAmount
        /// </summary>
        public float TaxAmount { get; set; }
        /// <summary>
        /// Overbid
        /// </summary>
        public float Overbid { get; set; }
        /// <summary>
        /// TotalAmount
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// RedemptionDate
        /// </summary>
        public string RedemptionDate { get; set; }
        /// <summary>
        /// StateName
        /// </summary>
        public string StateName { get; set; }
    }
}