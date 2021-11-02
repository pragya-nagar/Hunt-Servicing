using Services.CustomerService.Command;
using Services.CustomerService.ViewModel;
using Services.CustomerService.ViewModel.ContactViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// IContactRepository
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// GetContactListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<ContactDetailsEntity>> GetContactListByAssetId(string assetId);
        /// <summary>
        /// GetContactTypeList
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactTypeEntity>> GetContactTypeList();
        /// <summary>
        /// UpdateContactFlagByContactId
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        Task<int> UpdateContactFlagByContactId(int contactId);
        /// <summary>
        /// CreateContact
        /// </summary>
        /// <param name="createContactCommand"></param>
        /// <returns></returns>
        Task<int> CreateContact(CreateContactCommand createContactCommand);
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
        /// UpdateContact
        /// </summary>
        /// <param name="updateContactCommand"></param>
        /// <returns></returns>
        Task<int> UpdateContact(UpdateContactCommand updateContactCommand);
    }
}
