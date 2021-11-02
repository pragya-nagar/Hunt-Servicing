using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// ContactEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactEntity
    {
        /// <summary>
        /// ContactId
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public string ContactName { get; set; }
    }
}
