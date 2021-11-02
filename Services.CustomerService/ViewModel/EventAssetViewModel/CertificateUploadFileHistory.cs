using System;

namespace Services.CustomerService.ViewModel.EventAssetViewModel
{
    /// <summary>
    /// This class used for Certificate Upload File History list.
    /// </summary>
    public class CertificateUploadFileHistory
    {
        /// <summary>
        /// Gets or sets the certificate upload file identifier.
        /// </summary>
        /// <value>
        /// The certificate upload file identifier.
        /// </value>
        public int CertificateUploadFileId { get; set; }
        /// <summary>
        /// Gets or sets the name of the certificate upload file.
        /// </summary>
        /// <value>
        /// The name of the certificate upload file.
        /// </value>
        public string CertificateUploadFileName { get; set; }
        /// <summary>
        /// Gets or sets the total record uploaded.
        /// </summary>
        /// <value>
        /// The total record uploaded.
        /// </value>
        public int TotalRecordUploaded { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is processed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is processed; otherwise, <c>false</c>.
        /// </value>
        public bool IsProcessed { get; set; }
        /// <summary>
        /// Gets or sets the certificate status.
        /// </summary>
        /// <value>
        /// The certificate status.
        /// </value>
        public string CertificateStatus { get; set; }
        /// <summary>
        /// Gets or sets the certificate generated date.
        /// </summary>
        /// <value>
        /// The certificate generated date.
        /// </value>
        public string CertificateGeneratedDate { get; set; }
        /// <summary>
        /// Gets or sets the uploaded date.
        /// </summary>
        /// <value>
        /// The uploaded date.
        /// </value>
        public string UploadedDate { get; set; }
        /// <summary>
        /// Gets or sets the created by user initial.
        /// </summary>
        /// <value>
        /// The created by user initial.
        /// </value>
        public string CreatedByUserInitial { get; set; }
        /// <summary>
        /// Gets or sets the updated by user initial.
        /// </summary>
        /// <value>
        /// The updated by user initial.
        /// </value>
        public string UpdatedByUserInitial { get; set; }
    }
}
