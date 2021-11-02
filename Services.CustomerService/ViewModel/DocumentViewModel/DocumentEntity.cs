using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.DocumentViewModel
{
    /// <summary>
    /// DocumentEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DocumentEntity
    {
        /// <summary>
        /// DocumentId
        /// </summary>
        public int DocumentId { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public string AssetId { get; set; }
        /// <summary>
        /// DocumentType
        /// </summary>
        public string DocumentType { get; set; }
        /// <summary>
        /// DocumentTitle
        /// </summary>
        public string DocumentTitle { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// DocumentReceiveDate
        /// </summary>
        public string DocumentReceiveDate { get; set; }
        /// <summary>
        /// DocumentUploadDate
        /// </summary>
        public string DocumentUploadDate { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// UploadedFileNames
        /// </summary>
        public List<DocumentFileEntity> UploadedFileNames { get; set; }
        /// <summary>
        /// CreatedByUserInitial
        /// </summary>
        public string CreatedByUserInitial { get; set; }
        /// <summary>
        /// UpdatedByUserInitial
        /// </summary>
        public string UpdatedByUserInitial { get; set; }
    }
}
