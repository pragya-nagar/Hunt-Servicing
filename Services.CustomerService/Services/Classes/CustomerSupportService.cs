using Microsoft.Extensions.Logging;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.ViewModel;
using Services.CustomerService.ViewModel.ContactViewModel;
using Services.CustomerService.ViewModel.DocumentViewModel;
using Services.CustomerService.ViewModel.OwnerViewModel;
using Services.CustomerService.ViewModel.PropertyViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Services.Classes
{
    /// <summary>
    /// CustomerSupportService
    /// </summary>
    public class CustomerSupportService : ICustomerSupportService
    {
        private readonly IStateRepository _IStateRepository;
        private readonly IEventRepository _IEventRepository;
        private readonly IOwnerRepository _IOwnerRepository;
        private readonly IContactRepository _IContactRepository;
        private readonly IPropertyRepository _IPropertyRepository;
        private readonly IDocumentRepository _IDocumentRepository;
        private readonly ILogger _logger;
        /// <summary>
        /// CustomerSupportService
        /// </summary>
        /// <param name="documentRepository"></param>
        /// <param name="propertyRepository"></param>
        /// <param name="contactRepository"></param>
        /// <param name="ownerRepository"></param>
        /// <param name="stateRepository"></param>
        /// <param name="eventRepository"></param>
        /// <param name="logger"></param>[
        public CustomerSupportService(IDocumentRepository documentRepository, IPropertyRepository propertyRepository, IContactRepository contactRepository, IOwnerRepository ownerRepository, IStateRepository stateRepository, IEventRepository eventRepository, ILogger<ICustomerSupportService> logger)
        {
            this._logger = logger;
            this._IStateRepository = stateRepository;
            this._IEventRepository = eventRepository;
            this._IOwnerRepository = ownerRepository;
            this._IContactRepository = contactRepository;
            this._IPropertyRepository = propertyRepository;
            this._IDocumentRepository = documentRepository;
        }
        /// <summary>
        /// GetListAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StateListEntity>> GetListAsync()
        {
            this._logger.LogInformation("GetListAsync() triggered to get State master data");
            return await this._IStateRepository.GetStateList();
        }
        /// <summary>
        /// GetAssetStatusListAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AssetStatusEntity>> GetAssetStatusListAsync()
        {
            this._logger.LogInformation("GetAssetStatusListAsync() triggered to get State Asset Status master data");
            return await this._IStateRepository.GetAssetStatusList();
        }
        /// <summary>
        /// GetGlobalSearchOptionList
        /// </summary>
        /// <param name="filterValue"></param>
        /// <param name="parStateList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GlobalSearchOptionEntity>> GetGlobalSearchOptionList(string filterValue, string parStateList)
        {
            this._logger.LogInformation("GetGlobalSearchOptionList() triggered to get State Global Search Option master data");
            return await this._IStateRepository.GetGlobalSearchOptionList(filterValue, parStateList);
        }
        /// <summary>
        /// GetGlobalPopUpSearchOptionListByParcelId
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="searchValue"></param>
        /// <param name="stateList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchOptionListByParcelId(string parcelId, string searchValue, string stateList)
        {
            this._logger.LogInformation("GetGlobalPopUpSearchOptionListByParcelId() triggered to get State Global Pop Up Search Option master data");
            return await this._IStateRepository.GetGlobalPopUpSearchOptionListByParcelId(parcelId, searchValue, stateList);
        }
        /// <summary>
        /// GetGlobalPopUpSearchResultByParcelIdAndAssetId
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetId"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchResultByParcelIdAndAssetId(string parcelId, string assetId, string searchValue)
        {
            this._logger.LogInformation("GetGlobalPopUpSearchResultByParcelIdAndAssetId() triggered to get State Global Pop Up Search Result data");
            return await this._IStateRepository.GetGlobalPopUpSearchResultByParcelIdAndAssetId(parcelId, assetId, searchValue);
        }
        /// <summary>
        /// GetGlobalSearchOptionListAdvanced
        /// </summary>
        /// <param name="globalSearchOptionEntity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchGridResponseEntity>> GetGlobalSearchOptionListAdvanced(GlobalSearchOptionInputAdvancedEntity globalSearchOptionEntity)
        {
            this._logger.LogInformation("GetGlobalSearchOptionListAdvanced() triggered to get State Global Search Option Advanced master data");
            return await this._IStateRepository.GetGlobalSearchOptionListAdvanced(globalSearchOptionEntity);
        }
        /// <summary>
        /// GetLienHeaderInfoByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<LienHeaderInfoEntity> GetLienHeaderInfoByAssetId(string assetId)
        {
            this._logger.LogInformation("GetLienHeaderInfoByAssetId() triggered to get State Lien Header Info data");
            return await this._IStateRepository.GetLienHeaderInfoByAssetId(assetId);
        }
        /// <summary>
        /// GetLienAssetInfoByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LienAssetInfoEntity>> GetLienAssetInfoByAssetId(string assetId)
        {
            this._logger.LogInformation("GetLienAssetInfoByAssetId() triggered to get State Lien Asset Info data");
            return await this._IStateRepository.GetLienAssetInfoByAssetId(assetId);
        }
        /// <summary>
        /// GetLienRecentActivityByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="hasLimit"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LienRecentActivityEntity>> GetLienRecentActivityByAssetId(string assetId, bool hasLimit = false)
        {
            this._logger.LogInformation("GetLienRecentActivityByAssetId() triggered to get State Lien Recent Activity data");
            return await this._IStateRepository.GetLienRecentActivityByAssetId(assetId, hasLimit);
        }
        /// <summary>
        /// GetEventTypeByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventTypeEntity>> GetEventTypeByAssetId(string assetId)
        {
            this._logger.LogInformation("GetEventTypeByAssetId() triggered to get State Event Type data");
            return await this._IStateRepository.GetEventTypeByAssetId(assetId);
        }
        /// <summary>
        /// GetFlagActionByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FlagActionEntity>> GetFlagActionByAssetId(string assetId)
        {
            this._logger.LogInformation("GetFlagActionByAssetId() triggered to get State Flag Action data");
            return await this._IStateRepository.GetFlagActionByAssetId(assetId);
        }
        /// <summary>
        /// GetOtherActionByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FlagActionEntity>> GetOtherActionByAssetId(string assetId)
        {
            this._logger.LogInformation("GetOtherActionByAssetId() triggered to get additional State Flag Action data");
            return await this._IStateRepository.GetOtherActionByAssetId(assetId);
        }
        /// <summary>
        /// GetEventTypeList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventTypeEntity>> GetEventTypeList()
        {
            this._logger.LogInformation("GetEventTypeList() triggered to get Event Type master data");
            return await this._IEventRepository.GetEventTypeList();
        }
        /// <summary>
        /// GetEventActionList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventActionEntity>> GetEventActionList()
        {
            this._logger.LogInformation("GetEventActionList() triggered to get Event master data");
            return await this._IEventRepository.GetEventActionList();
        }
        /// <summary>
        /// GetRelatedAsset
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="parcelId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RelatedAssetEntity>> GetRelatedAsset(string assetId, string parcelId)
        {
            this._logger.LogInformation("GetRelatedAsset() triggered to get Event Related Asset data");
            return await this._IEventRepository.GetRelatedAsset(assetId, parcelId);
        }
        /// <summary>
        /// GetContactByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContactEntity>> GetContactByAssetId(string assetId)
        {
            this._logger.LogInformation("GetContactByAssetId() triggered to get Event Contact data");
            return await this._IEventRepository.GetContactByAssetId(assetId);
        }
        /// <summary>
        /// GetEventActionCategoryList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventActionCategoryEntity>> GetEventActionCategoryList()
        {
            this._logger.LogInformation("GetEventActionCategoryList() triggered to get Event Action Category data");
            return await this._IEventRepository.GetEventActionCategoryList();
        }
        /// <summary>
        /// GetOwnerListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OwnerEntity>> GetOwnerListByAssetId(string assetId)
        {
            this._logger.LogInformation("GetOwnerListByAssetId() triggered to get Owner data");
            return await this._IOwnerRepository.GetOwnerListByAssetId(assetId);
        }
        /// <summary>
        /// GetContactListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContactDetailsEntity>> GetContactListByAssetId(string assetId)
        {
            this._logger.LogInformation("GetContactListByAssetId() triggered to get Contact data");
            return await this._IContactRepository.GetContactListByAssetId(assetId);
        }
        /// <summary>
        /// GetContactType
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactTypeEntity>> GetContactType()
        {
            this._logger.LogInformation("GetContactType() triggered to get Contact Type data");
            return await this._IContactRepository.GetContactTypeList();
        }
        /// <summary>
        /// GetCityList
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CityEntity>> GetCityList(int stateId)
        {
            this._logger.LogInformation("GetCityList() triggered to get City master data");
            return await this._IContactRepository.GetCityList(stateId);
        }

        /// <summary>
        /// GetContactByContactId
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<ManageContact> GetContactByContactId(int contactId)
        {
            this._logger.LogInformation("GetContactByContactId() Get Contact Data");
            return await this._IContactRepository.GetContactByContactId(contactId);
        }
        /// <summary>
        /// GetLienCountAssetDetails
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetStatus"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RelatedAssetEntity>> GetLienCountAssetDetails(string parcelId, string assetStatus)
        {
            this._logger.LogInformation("GetRelatedAsset() triggered to get Event Related Asset data");
            return await this._IEventRepository.GetLienCountAssetDetails(parcelId, assetStatus);
        }
        /// <summary>
        /// GetPropertyInfoByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyDetailsEntity>> GetPropertyInfoByAssetId(string assetId)
        {
            this._logger.LogInformation("GetRelatedAsset() triggered to get Event Related Asset data");
            return await this._IPropertyRepository.GetPropertyInfoByAssetId(assetId);
        }
        /// <summary>
        /// GetDocumentListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentEntity>> GetDocumentListByAssetId(string assetId)
        {
            this._logger.LogInformation("GetRelatedAsset() triggered to get Event Related Asset data");
            return await this._IDocumentRepository.GetDocumentListByAssetId(assetId);
        }
        /// <summary>
        /// GetDocumentType
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentTypeEntity>> GetDocumentType()
        {
            this._logger.LogInformation("GetDocumentType()");
            return await this._IDocumentRepository.GetDocumentType();
        }
        /// <summary>
        /// assetId
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<int> UpdateDocumentFlagByDocumentId(int documentId, string assetId)
        {
            this._logger.LogInformation("UpdateDocumentFlagByContactId()");
            return await this._IDocumentRepository.UpdateDocumentFlagByDocumentId(documentId, assetId);
        }
        /// <summary>
        /// GetPropertyListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyDetailsEntity>> GetPropertyListByAssetId(string assetId)
        {
            this._logger.LogInformation("GetPropertyListByAssetId()");
            return await this._IPropertyRepository.GetPropertyListByAssetId(assetId);
        }
        /// <summary>
        /// DownloadFileAsync
        /// </summary>
        /// <param name="documentFileId"></param>
        /// <returns></returns>
        public async Task<string> DownloadFileAsync(int documentFileId)
        {
            this._logger.LogInformation("GetPropertyListByAssetId()");
            return await this._IDocumentRepository.DownloadFileAsync(documentFileId);
        }
    }
}
