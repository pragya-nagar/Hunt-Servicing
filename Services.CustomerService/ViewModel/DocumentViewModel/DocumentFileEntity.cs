using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.DocumentViewModel
{
    /// <summary>
    /// DocumentFileEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DocumentFileEntity
    {
        /// <summary>
        /// DocumentFileId
        /// </summary>
        public int DocumentFileId { get; set; }
        /// <summary>
        /// UploadedFileName
        /// </summary>
        public string UploadedFileName { get; set; }
        /// <summary>
        /// UploadFileKey
        /// </summary>
        public string UploadFileKey { get; set; }
    }
}
