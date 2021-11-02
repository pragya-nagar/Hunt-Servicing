namespace Services.CustomerService.ViewModel.EventAssetViewModel
{
    /// <summary>
    /// EventMasterEntity
    /// </summary>
    public class EventMasterEntity
    {
        /// <summary>
        /// EventId
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
        /// AcquisitionDate
        /// </summary>
        public string AcquisitionDate { get; set; }
        /// <summary>
        /// FinancialGroup
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
        /// NoOfCountActive
        /// </summary>
        public int NumberOfLienCountActive { get; set; }
        /// <summary>
        /// NoOfCountRedeemed
        /// </summary>
        public int NumberOfLienCountRedeemed { get; set; }
        /// <summary>
        /// TotalTax
        /// </summary>
        public string TotalTaxAmount { get; set; }
        /// <summary>
        /// TotalOverbid
        /// </summary>
        public string TotalOverbid { get; set; }
        /// <summary>
        /// TotalInterestPenalty
        /// </summary>
        public string TotalPremium { get; set; }
        /// <summary>
        /// TotalInterestPenalty
        /// </summary>
        public string TotalInterestPenalty { get; set; }
        /// <summary>
        /// TotalFee
        /// </summary>
        public string TotalFee { get; set; }
        /// <summary>
        /// TotalPurchase
        /// </summary>
        public string TotalPurchase { get; set; }
        /// <summary>
        /// ImportDate
        /// </summary>
        public string ImportDate { get; set; }
        /// <summary>
        /// ApprovedDate
        /// </summary>
        public string ApprovedDate { get; set; }
        /// <summary>
        /// RejectedDate
        /// </summary>
        public string RejectedDate { get; set; }
        /// <summary>
        /// RejectedReason
        /// </summary>
        public string RejectedReason { get; set; }
        /// <summary>
        /// EventMasterId
        /// </summary>
        public int EventMasterId { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }
    }
}
