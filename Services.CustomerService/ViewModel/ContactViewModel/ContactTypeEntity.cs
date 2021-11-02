using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.ContactViewModel
{
    /// <summary>
    /// ContactTypeEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactTypeEntity
    {
        /// <summary>
        /// TypeName
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// ContactTypeId
        /// </summary>
        public int ContactTypeId { get; set; }
    }
}
