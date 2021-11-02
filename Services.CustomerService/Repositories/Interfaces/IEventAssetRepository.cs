using Services.CustomerService.Command;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.CustomerService.ViewModel.EventAssetViewModel;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// IEventAssetRepository
    /// </summary>
    public interface IEventAssetRepository
    {
        /// <summary>
        /// GetRejectReasonList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventMasterRejectionReasonEntity>> GetRejectReasonList();

        /// <summary>
        /// GetEventMasterList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventMasterEntity>> GetEventMaster(int eventMasterStatusId);

        /// <summary>
        /// RejectedEventsAction
        /// </summary>
        /// <param name="rejectedEventsActionCommand"></param>
        /// <returns></returns>
        Task<int> RejectedEventsAction(RejectedEventsActionCommand rejectedEventsActionCommand);
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
    }
}
