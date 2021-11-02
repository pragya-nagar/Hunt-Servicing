using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// AdvancedSearchEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AdvancedSearchEntity : GlobalSearchOptionEntity
    {
        /// <summary>
        /// AlternativeID
        /// </summary>
        public int AlternativeID { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// Jurisdiction
        /// </summary>
        public int Jurisdiction { get; set; }
        /// <summary>
        /// AssetStatus
        /// </summary>
        public int AssetStatus { get; set; }
        /// <summary>
        /// LienHierarchy
        /// </summary>
        public int LienHierarchy { get; set; }
        /// <summary>
        /// AcquisitionDate
        /// </summary>
        public int AcquisitionDate { get; set; }
        /// <summary>
        /// PurchasingEntity
        /// </summary>
        public int PurchasingEntity { get; set; }
        /// <summary>
        /// CurrentEntity
        /// </summary>
        public int CurrentEntity { get; set; }
        /// <summary>
        /// FinancingGroup
        /// </summary>
        public int FinancingGroup { get; set; }
        /// <summary>
        /// AttorneyName
        /// </summary>
        public int AttorneyName { get; set; }
    }
}
