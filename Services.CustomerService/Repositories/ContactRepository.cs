using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel;
using Services.CustomerService.ViewModel.ContactViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Services.Common.Constants;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// ContactsRepository
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly ILogger _logger;
        /// <summary>
        /// _conn
        /// </summary>
        public string _conn { get; set; }
        /// <summary>
        /// EventRepository
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public ContactRepository(ILogger<ContactRepository> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }
        /// <summary>
        /// GetContactListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContactDetailsEntity>> GetContactListByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetContactListByAssetId() triggered to get contact master data ");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = ContactServiceQueries.GetContactByAssetIdQuery;
                    var parameters = new DynamicParameters();
                    parameters.Add("@assetId", assetId, DbType.String);
                    IEnumerable<ContactDetailsEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<ContactDetailsEntity>(sql, parameters);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetContactListByAssetId() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetContactTypeList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactTypeEntity>> GetContactTypeList()
        {
            try
            {
                this._logger.LogInformation("GetContactTypeList() By Default");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = ContactServiceQueries.GetContactType;
                    IEnumerable<ContactTypeEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<ContactTypeEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetContactTypeList() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// UpdateContactFlagByContactId
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<int> UpdateContactFlagByContactId(int contactId)
        {
            try
            {
                if (contactId > 0)
                {
                    this._logger.LogInformation("UpdateContactFlagByContactId() triggered to update contacts flag");
                    string updateQuery = ContactServiceQueries.UpdateIsDeletedFlagByContactId;
                    string deleteAssetContact = ContactServiceQueries.DeleteAssetContactByContactId;

                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@contactId", contactId);

                        int result = 0;
                        if (_conn != null)
                        {
                            result = await conn.ExecuteAsync(updateQuery, parameters);
                            await conn.ExecuteAsync(deleteAssetContact, parameters);
                        }

                        return result;
                    }
                }
                else
                {
                    this._logger.LogInformation("Invalid Contact ID found while executing UpdateContactFlagByContactId() in ContactRepository");
                    return await Task.FromException<int>(new ArgumentException("Update failed ..."));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing UpdateContactFlagByContactId() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// UpdateContactFlagByContactId
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<int> CreateContactFlagByContactId(int contactId)
        {
            try
            {
                if (contactId > 0)
                {
                    this._logger.LogInformation("CreateContactFlagByContactId() triggered to update contacts flag");
                    string updateQuery = ContactServiceQueries.UpdateIsDeletedFlagByContactId;
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        int result = 0;
                        if (_conn != null)
                            result = await conn.ExecuteAsync(updateQuery, new
                            {
                                contactId
                            });
                        return result;
                    }
                }
                else
                {
                    this._logger.LogInformation("Invalid Contact ID found while executing CreateContactFlagByContactId() in ContactRepository");
                    return await Task.FromException<int>(new ArgumentException("Update failed ..."));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing CreateContactFlagByContactId() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// CreateContact
        /// </summary>
        /// <param name="createContactCommand"></param>
        /// <returns></returns>
        public async Task<int> CreateContact(CreateContactCommand createContactCommand)
        {
            try
            {
                this._logger.LogInformation("CreateContact() By command");
                if (!string.IsNullOrWhiteSpace(createContactCommand.FirstName))
                {
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        string sp = ContactServiceQueries.CreateContact;
                        var parameters = new DynamicParameters();
                        parameters.Add("@v_AssetId", createContactCommand.AssetId);
                        parameters.Add("@v_FirstName", createContactCommand.FirstName);
                        parameters.Add("@v_LastName", createContactCommand.LastName);
                        parameters.Add("@v_ContactAddress", createContactCommand.ContactAddress);
                        parameters.Add("@v_ContactCityId", createContactCommand.ContactCityId);
                        parameters.Add("@v_ContactStateId", createContactCommand.ContactStateId);
                        parameters.Add("@v_ContactZipCode", createContactCommand.ContactZipCode);
                        parameters.Add("@v_ContactTypeId", createContactCommand.ContactTypeId);
                        parameters.Add("@v_Company", createContactCommand.Company);
                        parameters.Add("@v_CellPhone", createContactCommand.CellPhone);
                        parameters.Add("@v_HomePhone", createContactCommand.HomePhone);
                        parameters.Add("@v_WorkPhone", createContactCommand.WorkPhone);
                        parameters.Add("@v_Fax", createContactCommand.Fax);
                        parameters.Add("@v_Email", createContactCommand.Email);
                        parameters.Add("@v_DoNotContactFlag", createContactCommand.DoNotContactFlag);
                        parameters.Add("@v_Note", createContactCommand.Note);
                        parameters.Add("@v_CreatedBy", createContactCommand.CreatedBy);
                        int result = 0;
                        if (_conn != null)
                            result = await conn.QueryFirstOrDefaultAsync<int>(sp, parameters, commandType: CommandType.StoredProcedure);
                        return result;
                    }
                }
                else
                {
                    this._logger.LogInformation("First name not found in attached command while executing CreateContact() in ContactRepository");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing CreateContact() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetContactTypeList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CityEntity>> GetCityList(int stateId)
        {
            try
            {
                this._logger.LogInformation("GetCityList() By State Id");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = ContactServiceQueries.GetCityByStateId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@stateId", stateId);

                    IEnumerable<CityEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<CityEntity>(sql, parameters);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetCityList() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetContactTypeList
        /// </summary>
        /// <returns></returns>
        public async Task<ManageContact> GetContactByContactId(int contactId)
        {
            try
            {
                this._logger.LogInformation("GetContactByContactId() triggered to get manage contact data");
                using (var connection = new NpgsqlConnection(this._conn))
                {

                    var sql = ContactServiceQueries.getContactByContactId;
                    var sql1 = ContactServiceQueries.getRelatedAssetByContactId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@contactId", contactId);

                    ManageContact mc = null;
                    if (_conn != null)
                    {
                        var assetIds = await connection.QueryAsync<string>(sql1, parameters);
                        var response = await connection.QueryAsync<CreateContactCommand>(sql, parameters);

                        mc = new ManageContact()
                        {
                            AssetId = assetIds.ToList(),
                            createContactCommand = response.Select(i => i).FirstOrDefault()
                        };
                    }
                    return mc;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetContactByContactId() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// updateContactCommand
        /// </summary>
        /// <param name="updateContactCommand"></param>
        /// <returns></returns>
        public async Task<int> UpdateContact(UpdateContactCommand updateContactCommand)
        {
            try
            {
                this._logger.LogInformation("UpdateContact() By Command");
                if (!string.IsNullOrWhiteSpace(updateContactCommand.FirstName))
                {
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        string sp = ContactServiceQueries.UpdateContact;
                        var parameters = new DynamicParameters();
                        parameters.Add("@v_ContactId", updateContactCommand.ContactId);
                        parameters.Add("@v_AssetId", updateContactCommand.AssetId);
                        parameters.Add("@v_FirstName", updateContactCommand.FirstName);
                        parameters.Add("@v_LastName", updateContactCommand.LastName);
                        parameters.Add("@v_ContactAddress", updateContactCommand.ContactAddress);
                        parameters.Add("@v_ContactCityId", updateContactCommand.ContactCityId);
                        parameters.Add("@v_ContactStateId", updateContactCommand.ContactStateId);
                        parameters.Add("@v_ContactZipCode", updateContactCommand.ContactZipCode);
                        parameters.Add("@v_ContactTypeId", updateContactCommand.ContactTypeId);
                        parameters.Add("@v_Company", updateContactCommand.Company);
                        parameters.Add("@v_CellPhone", updateContactCommand.CellPhone);
                        parameters.Add("@v_HomePhone", updateContactCommand.HomePhone);
                        parameters.Add("@v_WorkPhone", updateContactCommand.WorkPhone);
                        parameters.Add("@v_Fax", updateContactCommand.Fax);
                        parameters.Add("@v_Email", updateContactCommand.Email);
                        parameters.Add("@v_DoNotContactFlag", updateContactCommand.DoNotContactFlag);
                        parameters.Add("@v_Note", updateContactCommand.Note);
                        parameters.Add("@v_UpdatedBy", updateContactCommand.UpdatedBy);
                        int result = 0;
                        if (_conn != null)
                            result = await conn.QueryFirstOrDefaultAsync<int>(sp, parameters, commandType: CommandType.StoredProcedure);
                        return result;
                    }
                }
                else
                {
                    this._logger.LogInformation("First name not found in attached command while executing UpdateContact() in ContactRepository");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing UpdateContact() in ContactRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
