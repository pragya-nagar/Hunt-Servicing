using Services.CustomerService.ViewModel;
using Services.CustomerService.ViewModel.ContactViewModel;
using Services.CustomerService.ViewModel.DocumentViewModel;
using Services.CustomerService.ViewModel.OwnerViewModel;
using Services.CustomerService.ViewModel.PropertyViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Services.Interfaces
{
    /// <summary>
    /// ICustomerSupportService
    /// </summary>
    public interface ICustomerSupportService
    {
        /// <summary>
        /// GetListAsync
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StateListEntity>> GetListAsync();
        /// <summary>
        /// GetAssetStatusListAsync
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AssetStatusEntity>> GetAssetStatusListAsync();
        /// <summary>
        /// GetGlobalSearchOptionList
        /// </summary>
        /// <param name="filterValue"></param>
        /// <param name="parStateList"></param>
        /// <returns></returns>
        Task<IEnumerable<GlobalSearchOptionEntity>> GetGlobalSearchOptionList(string filterValue, string parStateList);
        
        /// <summary>
        /// SearchGridResponseEntity
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="searchValue"></param>
        /// <param name="stateList"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchOptionListByParcelId(string parcelId, string searchValue, string stateList);
        /// <summary>
        /// GetGlobalSearchOptionListAdvanced
        /// </summary>
        /// <param name="globalSearchOptionEntity"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchGridResponseEntity>> GetGlobalSearchOptionListAdvanced(GlobalSearchOptionInputAdvancedEntity globalSearchOptionEntity);
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
        /// <param name="assetId"></param>
        /// <param name="hasLimit"></param>
        /// <returns></returns>
        Task<IEnumerable<LienRecentActivityEntity>> GetLienRecentActivityByAssetId(string assetId, bool hasLimit = false);
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
        /// GetEventActionCategoryList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventActionCategoryEntity>> GetEventActionCategoryList();
        /// <summary>
        /// GetGlobalPopUpSearchResultByParcelIdAndAssetId
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetId"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchResultByParcelIdAndAssetId(string parcelId, string assetId, string searchValue);
        /// <summary>
        /// GetOwnerListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<OwnerEntity>> GetOwnerListByAssetId(string assetId);
        /// <summary>
        /// GetContactListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<ContactDetailsEntity>> GetContactListByAssetId(string assetId);
        /// <summary>
        /// GetContactType
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactTypeEntity>> GetContactType();
        /// <summary>
        /// GetCityList
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        Task<IEnumerable<CityEntity>> GetCityList(int stateId);
        /// <summary>
        /// GetContactByContactId
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<ManageContact> GetContactByContactId(int contactId);
        /// <summary>
        /// GetLienCountAssetDetails
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetStatus"></param>
        /// <returns></returns>
        Task<IEnumerable<RelatedAssetEntity>> GetLienCountAssetDetails(string parcelId, string assetStatus);
        /// <summary>
        /// GetPropertyInfoByParcelId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<PropertyDetailsEntity>> GetPropertyInfoByAssetId(string assetId);
        /// <summary>
        /// GetDocumentListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<DocumentEntity>> GetDocumentListByAssetId(string assetId);
        /// <summary>
        /// GetDocumentType
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DocumentTypeEntity>> GetDocumentType();
        /// <summary>
        /// UpdateDocumentFlagByDocumentId
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<int> UpdateDocumentFlagByDocumentId(int documentId, string assetId);
        /// <summary>
        /// GetPropertyListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<PropertyDetailsEntity>> GetPropertyListByAssetId(string assetId);
        /// <summary>
        /// DownloadFileAsync
        /// </summary>
        /// <param name="documentFileId"></param>
        /// <returns></returns>
        Task<string> DownloadFileAsync(int documentFileId);
    }
}
