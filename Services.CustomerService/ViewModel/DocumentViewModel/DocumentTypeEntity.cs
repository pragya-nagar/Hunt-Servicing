using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.DocumentViewModel
{
    /// <summary>
    /// DocumentTypeEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DocumentTypeEntity
    {
        /// <summary>
        /// DocumentTypeId
        /// </summary>
        public int DocumentTypeId { get; set; }
        /// <summary>
        /// DocumentTypeName
        /// </summary>
        public string DocumentTypeName { get; set; }
    }
}
