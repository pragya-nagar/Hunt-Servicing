using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CustomerService.Command;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.ViewModel;

namespace Services.CustomerService.Controllers
{
    /// <summary>
    /// AssetServiceController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssetServiceController : ControllerBase
    {
        /// <summary>
        /// The customer service
        /// </summary>
        private readonly ICustomerSupportService _ICustomerService;
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// CustomerController Constructor
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        /// <param name="mediator">The mediator.</param>
        /// <exception cref="ArgumentNullException">mediator</exception>
        public AssetServiceController(ICustomerSupportService customerService, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._ICustomerService = customerService;
        }
        /// <summary>
        /// Get States List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/state/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetStateList()
        {
            var result = await this._ICustomerService.GetListAsync();
            return this.Ok(result);
        }
        /// <summary>
        /// Get Asset Status List.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/assetstatus/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetAssetStatusList()
        {
            var result = await this._ICustomerService.GetAssetStatusListAsync();
            return this.Ok(result);
        }
        /// <summary>
        /// Get Event Type List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/eventtype/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetEventTypeList()
        {
            var result = await this._ICustomerService.GetEventTypeList();
            return this.Ok(result);
        }
        /// <summary>
        /// Get Event Action List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/eventaction/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetEventActionList()
        {
            var result = await this._ICustomerService.GetEventActionList();
            return this.Ok(result);
        }
        /// <summary>
        /// GetGlobalSearchOptionList
        /// Grab data from API for Auto Search functionality
        /// </summary>
        /// <param name="filterValue">The filter value.</param>
        /// <param name="parStateList">The par state list.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/globalsearchoption/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetGlobalSearchOptionList([FromQuery]string filterValue, [FromQuery] string parStateList)
        {
            parStateList = (string.IsNullOrWhiteSpace(parStateList)) ? null : parStateList;
            var result = await this._ICustomerService.GetGlobalSearchOptionList(filterValue, parStateList);
            return this.Ok(result);
        }
        
        /// <summary>
        /// Get GlobalPopUpSearch OptionList By ParcelId
        /// </summary>
        /// <param name="parcelId">The parcel id.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/globalpopupsearchoptionlistbyparcelid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetGlobalPopUpSearchOptionListByParcelId([FromQuery]string parcelId, string searchValue, string stateList)
        {
            var result = await this._ICustomerService.GetGlobalPopUpSearchOptionListByParcelId(parcelId, searchValue, stateList);
            return this.Ok(result);
        }
        /// <summary>
        /// Get GlobalPopUp SearchResult By ParcelIdAndAssetId
        /// When user choose value from auto suggestion pop-up
        /// </summary>
        /// <param name="parcelId">The parcel id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <param name="searchValue">The search value.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/globalpopupsearchresultbyparcelidandassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetGlobalPopUpSearchResultByParcelIdAndAssetId([FromQuery]string parcelId, [FromQuery]string assetId, [FromQuery] string searchValue)
        {
            var result = await this._ICustomerService.GetGlobalPopUpSearchResultByParcelIdAndAssetId(parcelId, assetId, searchValue);
            return this.Ok(result);
        }
        /// <summary>
        /// Grab Advanced Search Data
        /// </summary>
        /// <param name="globalSearchOptionEntity">The global search option entity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/globalsearchoptionlistadvanced/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetGlobalSearchOptionListAdvanced([FromBody]GlobalSearchOptionInputAdvancedEntity globalSearchOptionEntity)
        {
            var result = await this._ICustomerService.GetGlobalSearchOptionListAdvanced(globalSearchOptionEntity);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Lien Header Info
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/lienheaderinfobyassetId/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetLienHeaderInfoByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetLienHeaderInfoByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Lien Asset Info Based On Asset Id
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/lienassetinfobyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetLienAssetInfoByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetLienAssetInfoByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Lien Recent Activity By Asset ID
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <param name="hasLimit">if set to <c>true</c> [has limit].</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/lienrecentactivityinfobyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetLienRecentActivityInfoByAssetId(string assetId, bool hasLimit = false)
        {
            var result = await this._ICustomerService.GetLienRecentActivityByAssetId(assetId, hasLimit);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Event Type Data Based On AssetId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/eventtypebyassetId/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetEventTypeByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetEventTypeByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Action Data those flag is active based on AssetId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/flagactionbyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetFlagActionByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetFlagActionByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Action Data those flag is in-active based on AssetId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/otheractionbyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetOtherActionByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetOtherActionByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Mark Event Flag Active
        /// </summary>
        /// <param name="updateEventTypeFlagCommand">The update event type flag command.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("~/updateevent/flag/put")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutUpdateEventFlag(UpdateEventTypeFlagCommand updateEventTypeFlagCommand)
        {
            var result = await _mediator.Send(updateEventTypeFlagCommand);
            if (result == 1)
            {
                return this.Ok(result);
            }
            else
            {
                // returning no content if the update is unsuccessful
                return this.Ok(0);
            }
        }
        /// <summary>
        /// Mark Event Flag InActive
        /// </summary>
        /// <param name="removeEventTypeFlagCommand">The remove event type flag command.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("~/removeevent/flag/delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutRemoveEventFlag(RemoveEventTypeFlagCommand removeEventTypeFlagCommand)
        {
            var result = await _mediator.Send(removeEventTypeFlagCommand);
            if (result == 1)
            {
                return this.Ok(result);
            }
            else
            {
                // returning no content if the update is unsuccessful
                return this.Ok(0);
            }
        }
        /// <summary>
        /// Get AddEvent Related Asset
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <param name="parcelId">The parcel id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/relatedasset/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetRelatedAsset(string assetId, string parcelId)
        {
            var result = await this._ICustomerService.GetRelatedAsset(assetId, parcelId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Contact By Asset
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/contactbyasset/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetContactByAsset(string assetId)
        {
            var result = await this._ICustomerService.GetContactByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="createEventCommand">The create event command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/createevent/flag/post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateEvent(CreateEventCommand createEventCommand)
        {
            if (ModelState.IsValid && (createEventCommand.AssetId != null))
            {
                var result = await _mediator.Send(createEventCommand);
                return this.Ok(result);
            }
            else
                return this.Ok(0);
        }
        /// <summary>
        /// Get All Event Action Category List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/eventactioncategory/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetEventActionCategoryList()
        {
            var result = await this._ICustomerService.GetEventActionCategoryList();
            return this.Ok(result);
        }
        /// <summary>
        /// Get OwnerList By AssetId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/ownerlistbyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetOwnerListByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetOwnerListByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get ContactList By AssetId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/contactlistbyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetContactListByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetContactListByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Contact Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/contacttype/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetContactType()
        {
            var result = await this._ICustomerService.GetContactType();
            return this.Ok(result);
        }
        /// <summary>
        /// Delete Contact By Flag
        /// </summary>
        /// <param name="updateContactFlagCommand">The update contact flag command.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("~/contact/flag/delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteContactByFlag(UpdateContactFlagCommand updateContactFlagCommand)
        {
            var result = await _mediator.Send(updateContactFlagCommand);
            if (result == 1)
            {
                return this.Ok(result);
            }
            else
            {
                // returning no content if the update is unsuccessful
                return this.Ok(0);
            }
        }
        /// <summary>
        /// Create Contact
        /// </summary>
        /// <param name="createContactCommand">The create contact command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/contact/flag/post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateContact(CreateContactCommand createContactCommand)
        {
            if (ModelState.IsValid && (createContactCommand.AssetId != null))
            {
                var result = await _mediator.Send(createContactCommand);
                return this.Ok(result);
            }
            else
                return this.Ok(0);
        }
        /// <summary>
        /// Get CityList By StateId
        /// </summary>
        /// <param name="stateId">The state id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/citylistbystateid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetCityListByStateId(int stateId)
        {
            var result = await this._ICustomerService.GetCityList(stateId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get Contact By ContactId
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/contactbycontactid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetContactByContactId(int contactId)
        {
            var result = await this._ICustomerService.GetContactByContactId(contactId);
            return this.Ok(result);
        }
        /// <summary>
        /// UpdateEvent
        /// </summary>
        /// <param name="updateContactCommand">The update contact command.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("~/contact/flag/put")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand updateContactCommand)
        {
            if (ModelState.IsValid && (updateContactCommand.ContactId > 0))
            {
                var result = await _mediator.Send(updateContactCommand);
                return this.Ok(result);
            }
            else
                return this.Ok(0);
        }
        /// <summary>
        /// Get LienCount Asset Details
        /// </summary>
        /// <param name="parcelId">The parcel id.</param>
        /// <param name="assetStatus">The asset status.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/liencountassetdetails/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetLienCountAssetDetails(string parcelId, string assetStatus)
        {
            var result = await this._ICustomerService.GetLienCountAssetDetails(parcelId, assetStatus);
            return this.Ok(result);
        }
        /// <summary>
        /// Get PropertyInfo By ParcelId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/propertyinfobyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetPropertyInfoByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetPropertyInfoByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get DocumentList By AssetId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/documentlistbyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetDocumentListByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetDocumentListByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Get DocumentType
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/documenttype/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetDocumentType()
        {
            var result = await this._ICustomerService.GetDocumentType();
            return this.Ok(result);
        }
        /// <summary>
        /// Remove Document By DocumentId
        /// </summary>
        /// <param name="documentId">The document id.</param>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("~/documentbydocumentid/flag/put")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> RemoveDocumentByDocumentId(int documentId, string assetId)
        {
            var result = await this._ICustomerService.UpdateDocumentFlagByDocumentId(documentId, assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Create Document
        /// </summary>
        /// <param name="createDocumentCommand">The create document command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/document/flag/post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [RequestSizeLimit(200_000_000)]
        public async Task<IActionResult> CreateDocument(CreateDocumentCommand createDocumentCommand)
        {
            if (ModelState.IsValid && (createDocumentCommand.AssetId != null))
            {
                var result = await _mediator.Send(createDocumentCommand);
                return this.Ok(result);
            }
            else
                return this.Ok(0);
        }
        /// <summary>
        /// Get Property ListBy AssetId
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/propertylistbyassetid/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetPropertyListByAssetId(string assetId)
        {
            var result = await this._ICustomerService.GetPropertyListByAssetId(assetId);
            return this.Ok(result);
        }
        /// <summary>
        /// Download File Async
        /// </summary>
        /// <param name="documentFileId">The document file id.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/downloadfileasync/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> DownloadFileAsync(int documentFileId)
        {
            var result = await this._ICustomerService.DownloadFileAsync(documentFileId);
            return this.Ok(result);
        }
    }
}