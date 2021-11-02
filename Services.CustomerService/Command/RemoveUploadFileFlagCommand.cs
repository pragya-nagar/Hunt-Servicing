using MediatR;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// RemoveCertificateUploadFileFlagCommand
    /// </summary>
    public class RemoveUploadFileFlagCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the certificate upload file identifier.
        /// </summary>
        /// <value>
        /// The certificate upload file identifier.
        /// </value>
        public int CertificateUploadFileId { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Updated by User Initial.
        /// </summary>
        public string UpdatedByUserInitial { get; set; }
    }
}
