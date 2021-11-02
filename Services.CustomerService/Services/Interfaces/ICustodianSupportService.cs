using System.Collections.Generic;
using System.Threading.Tasks;
using Services.CustomerService.ViewModel.EventAssetViewModel;

namespace Services.CustomerService.Services.Interfaces
{
    /// <summary>
    /// ICustodianSupportService
    /// </summary>
    public interface ICustodianSupportService
    {
        /// <summary>
        /// GetRejectReasonList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventMasterRejectionReasonEntity>> GetRejectReasonList();

        /// <summary>
        /// GetEventMaster
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventMasterEntity>> GetEventMaster(int eventMasterStatusId);
        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDetailsHeaderEntity>> EventDetailsHeader(string eventId);

        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDetailsEntity>> EventDetails(string eventId);

        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task<IEnumerable<EventTypeAssetDetailsEntity>> EventDetailsAssetList(string eventId);

        /// <summary>
        /// Get the uploaded file history list.
        /// </summary>
        /// <param name="certificateStatusId">The certificate status.</param>
        /// <returns>Uploaded file list.</returns>
        Task<IEnumerable<CertificateUploadFileHistory>> GetUploadFileHistoryList(int certificateStatusId);
    }
}
