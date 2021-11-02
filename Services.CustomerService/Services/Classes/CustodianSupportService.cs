using Microsoft.Extensions.Logging;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.CustomerService.ViewModel.EventAssetViewModel;

namespace Services.CustomerService.Services.Classes
{
    /// <summary>
    /// CustodianSupportService
    /// </summary>
    public class CustodianSupportService : ICustodianSupportService
    {
        private readonly IEventAssetRepository _IEventAssetRepository;
        private readonly ICertificateUploadFileRepository _ICertificateUploadFileRepository;
        private readonly ILogger _logger;
      
        /// <summary>
        /// CustodianSupportService
        /// </summary>
        /// <param name="eventAssetRepository">The event asset repository.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="certificateUploadFileRepository">The certificate upload file repository.</param>
        public CustodianSupportService(IEventAssetRepository eventAssetRepository, ILogger<ICustodianSupportService> logger, ICertificateUploadFileRepository certificateUploadFileRepository)
        {
            this._logger = logger;
            this._IEventAssetRepository = eventAssetRepository;
            this._ICertificateUploadFileRepository = certificateUploadFileRepository;
        }

        /// <summary>
        /// GetRejectReasonList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventMasterRejectionReasonEntity>> GetRejectReasonList()
        {
            this._logger.LogInformation("GetRejectReasonList() triggered to get GetRejectReasonList master data");
            return await this._IEventAssetRepository.GetRejectReasonList();
        }
        
        /// <summary>
        /// GetPendingEvents
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventMasterEntity>> GetEventMaster(int eventMasterStatusId)
        {
            this._logger.LogInformation("GetPendingEvents() triggered to get GetPendingEvents master data");
            return await this._IEventAssetRepository.GetEventMaster(eventMasterStatusId);
        }
        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventDetailsHeaderEntity>> EventDetailsHeader(string eventId)
        {
            this._logger.LogInformation("GetPendingEvents() triggered to get GetPendingEvents master data");
            return await this._IEventAssetRepository.EventDetailsHeader(eventId);
        }

        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventDetailsEntity>> EventDetails(string eventId)
        {
            this._logger.LogInformation("GetPendingEvents() triggered to get GetPendingEvents master data");
            return await this._IEventAssetRepository.EventDetails(eventId);
        }

        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventTypeAssetDetailsEntity>> EventDetailsAssetList(string eventId)
        {
            this._logger.LogInformation("GetPendingEvents() triggered to get GetPendingEvents master data");
            return await this._IEventAssetRepository.EventDetailsAssetList(eventId);
        }

        /// <summary>
        /// Get the uploaded file history list.
        /// </summary>
        /// <param name="certificateStatusId">The certificate status.</param>
        /// <returns>Uploaded file list.</returns>
        public async Task<IEnumerable<CertificateUploadFileHistory>> GetUploadFileHistoryList(int certificateStatusId)
        {
            _logger.LogInformation("GetUploadFileHistoryList() triggered to get UploadFileHistoryList data");
            return await _ICertificateUploadFileRepository.GetUploadFileHistoryList(certificateStatusId);
        }
    }
}
