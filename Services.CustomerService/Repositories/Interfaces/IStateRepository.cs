using Services.CustomerService.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// IStateRepository
    /// </summary>
    public interface IStateRepository
    {
        /// <summary>
        /// GetStateList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StateListEntity>> GetStateList();
        /// <summary>
        /// GetAssetStatusList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AssetStatusEntity>> GetAssetStatusList();
        /// <summary>
        /// GetGlobalSearchOptionList
        /// </summary>
        /// <param name="filterValue"></param>
        /// <param name="stateList"></param>
        /// <returns></returns>
        Task<IEnumerable<GlobalSearchOptionEntity>> GetGlobalSearchOptionList(string filterValue, string stateList);
        /// <summary>
        /// GetGlobalSearchOptionListAdvanced
        /// </summary>
        /// <param name="globalSearchOptionEntity"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchGridResponseEntity>> GetGlobalSearchOptionListAdvanced(GlobalSearchOptionInputAdvancedEntity globalSearchOptionEntity);
       
        /// <summary>
        /// GetGlobalPopUpSearchOptionListByParcelId
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="searchValue"></param>
        /// <param name="stateList"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchOptionListByParcelId(string parcelId, string searchValue, string stateList);
        /// <summary>
        /// GetLienHeaderInfoByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<LienHeaderInfoEntity> GetLienHeaderInfoByAssetId(string assetId);
        /// <summary>
        /// GetLienAssetInfoByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<LienAssetInfoEntity>> GetLienAssetInfoByAssetId(string assetId);
        /// <summary>
        /// GetLienRecentActivityByAssetId
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="v_HasLimit">if set to <c>true</c> [v has limit].</param>
        /// <returns></returns>
        Task<IEnumerable<LienRecentActivityEntity>> GetLienRecentActivityByAssetId(string assetId, bool v_HasLimit = false);
        /// <summary>
        /// GetEventTypeByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<EventTypeEntity>> GetEventTypeByAssetId(string assetId);
        /// <summary>
        /// GetFlagActionByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<FlagActionEntity>> GetFlagActionByAssetId(string assetId);
        /// <summary>
        /// GetOtherActionByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<FlagActionEntity>> GetOtherActionByAssetId(string assetId);
        /// <summary>
        /// GetGlobalPopUpSearchResultByParcelIdAndAssetId
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetId"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchResultByParcelIdAndAssetId(string parcelId, string assetId, string searchValue);
    }
}
