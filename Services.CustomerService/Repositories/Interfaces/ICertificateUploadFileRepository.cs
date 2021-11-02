using Services.CustomerService.ViewModel.EventAssetViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.CustomerService.Command;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// CertificateUploadFileRepository Interface
    /// </summary>
    public interface ICertificateUploadFileRepository
    {
        /// <summary>
        /// This Method used t get uploaded file history list.
        /// </summary>
        /// <param name="certificateStatusId">The certificate status.</param>
        /// <returns>Uploaded file list.</returns>
        Task<IEnumerable<CertificateUploadFileHistory>> GetUploadFileHistoryList(int certificateStatusId);

        /// <summary>
        /// This method used to delete uploaded file by file id.
        /// </summary>
        /// <param name="uploadFileFlag">The uploaded file id.</param>
        /// <returns></returns>
        Task<int> DeleteUploadedFileByFileId(RemoveUploadFileFlagCommand uploadFileFlag);
    }
}
