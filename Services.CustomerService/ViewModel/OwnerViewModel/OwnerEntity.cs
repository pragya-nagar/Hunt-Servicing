using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.OwnerViewModel
{
    /// <summary>
    /// OwnerEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OwnerEntity
    {
        /// <summary>
        /// OwnerName
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// OwnerAddress
        /// </summary>
        public string OwnerAddress { get; set; }
        /// <summary>
        /// OwnerCity
        /// </summary>
        public string OwnerCity { get; set; }
        /// <summary>
        /// OwnerState
        /// </summary>
        public string OwnerState { get; set; }
        /// <summary>
        /// OwnerZipCode
        /// </summary>
        public string OwnerZipCode { get; set; }
        /// <summary>
        /// OwnerSocialSecurityNo
        /// </summary>
        public string OwnerSocialSecurityNo { get; set; }
        /// <summary>
        /// OwnerTaxId
        /// </summary>
        public string OwnerTaxId { get; set; }
        /// <summary>
        /// OwnerDob
        /// </summary>
        public string OwnerDob { get; set; }
    }
}
