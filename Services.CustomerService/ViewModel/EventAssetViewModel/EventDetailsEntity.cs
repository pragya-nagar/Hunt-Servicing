namespace Services.CustomerService.ViewModel.EventAssetViewModel
{
    /// <summary>
    /// EventDetailsEntity
    /// </summary>
    public class EventDetailsEntity
    {
        /// <summary>
        /// EventMasterId
        /// </summary>
        public int EventMasterId { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public string EventId { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string StateCode { get; set; }
       
        /// <summary>
        /// Jurisdiction
        /// </summary>
        public string Jurisdiction { get; set; }

        /// <summary>
        /// FinancingGroup
        /// </summary>
        public string FinancingGroup { get; set; }

        /// <summary>
        /// PurchasingEntity
        /// </summary>
        public string PurchasingEntity { get; set; }
        /// <summary>
        /// LienHierarchy
        /// </summary>
        public string LienHierarchy { get; set; }
        /// <summary>
        /// TotalInterest
        /// </summary>
        public string TotalInterestAndPenalty { get; set; }
        /// <summary>
        /// TotalTaxAmount
        /// </summary>
        public string TotalTaxAmount { get; set; }
        /// <summary>
        /// TotalOverbid
        /// </summary>
        public string TotalOverbid { get; set; }

        /// <summary>
        /// TotalPremium
        /// </summary>
        public string TotalPremium { get; set; }
        /// <summary>
        /// TotalPurchase
        /// </summary>
        public string TotalPurchase { get; set; }
        /// <summary>
        /// TotalFees
        /// </summary>
        public string TotalFee { get; set; }
        /// <summary>
        /// TotalAssets
        /// </summary>
        public int TotalAssets { get; set; }
        /// <summary>
        /// ApprovedDate
        /// </summary>
        public string ApprovedDate { get; set; }
        /// <summary>
        /// AcquisitionDate
        /// </summary>
        public string AcquisitionDate { get; set; }
    }
}
