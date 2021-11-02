using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.ContactViewModel
{
    /// <summary>
    /// ContactDetailsEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactDetailsEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// TypeName
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// ContactAddress
        /// </summary>
        public string ContactAddress { get; set; }
        /// <summary>
        /// CellPhone
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// DoNotContactFlag
        /// </summary>
        public bool DoNotContactFlag { get; set; }
        /// <summary>
        /// ContactId
        /// </summary>
        public int ContactId { get; set; }
    }
}
