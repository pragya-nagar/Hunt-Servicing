using Services.CustomerService.Command;
using Services.CustomerService.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// IEventRepository
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// UpdateEventTypeFlagByEventId
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task<int> UpdateEventTypeFlagByEventId(int eventId);
        /// <summary>
        /// RemoveEventTypeFlagByEventId
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task<int> RemoveEventTypeFlagByEventId(int eventId);
        /// <summary>
        /// GetEventTypeList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventTypeEntity>> GetEventTypeList();
        /// <summary>
        /// GetEventActionList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventActionEntity>> GetEventActionList();
        /// <summary>
        /// GetRelatedAsset
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="parcelId"></param>
        /// <returns></returns>
        Task<IEnumerable<RelatedAssetEntity>> GetRelatedAsset(string assetId, string parcelId);
        /// <summary>
        /// GetContactByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<ContactEntity>> GetContactByAssetId(string assetId);
        /// <summary>
        /// CreateEventId
        /// </summary>
        /// <param name="eventEntity"></param>
        /// <returns></returns>
        Task<int> CreateEventId(CreateEventCommand eventEntity);
        /// <summary>
        /// GetEventActionCategoryList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventActionCategoryEntity>> GetEventActionCategoryList();
        /// <summary>
        /// GetLienCountAssetDetails
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetStatus"></param>
        /// <returns></returns>
        Task<IEnumerable<RelatedAssetEntity>> GetLienCountAssetDetails(string parcelId, string assetStatus);
    }
}
