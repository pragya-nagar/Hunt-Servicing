using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Services.Common.Constants;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// EventRepository
    /// </summary>
    public class EventRepository : IEventRepository
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
        public EventRepository(ILogger<EventRepository> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }
        /// <summary>
        /// UpdateEventTypeFlagByEventId
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<int> UpdateEventTypeFlagByEventId(int eventId)
        {
            if (eventId > 0)
            {
                try
                {
                    this._logger.LogInformation("UpdateEventTypeFlagByEventId() triggered to update highlighted flag");
                    string updateQuery = EventRepositoryQueries.UpdateHighlightedFlagByEventId;
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        int result = 0;
                        if (_conn != null)
                            result = await conn.ExecuteAsync(updateQuery, new
                            {
                                eventId
                            });
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogError("Run time error while executing UpdateEventTypeFlagByEventId() in EventRepository with Message" + ex.Message);
                    throw;
                }
            }
            else
            {
                this._logger.LogError("Error while executing UpdateEventTypeFlagByEventId() in EventRepository as: Input parameter-eventId is not greater than zero");
                return await Task.FromException<int>(new ArgumentException("Update failed as either loan number or folder id is invalid"));
            }
        }
        /// <summary>
        /// RemoveEventTypeFlagByEventId
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<int> RemoveEventTypeFlagByEventId(int eventId)
        {
            if (eventId > 0)
            {
                try
                {
                    this._logger.LogInformation("RemoveEventTypeFlagByEventId() triggered to Remove Highlighted Flag");
                    string updateQuery = EventRepositoryQueries.RemoveHighlightedFlagByEventId;
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        int result = 0;
                        if (_conn != null)
                            result = await conn.ExecuteAsync(updateQuery, new
                            {
                                eventId
                            });
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogError("Run time error while executing RemoveEventTypeFlagByEventId() in EventRepository with Message" + ex.Message);
                    throw;
                }
            }
            else
            {
                this._logger.LogError("Error while executing RemoveEventTypeFlagByEventId() in EventRepository as: Input parameter-eventId is not greater than zero");
                return await Task.FromException<int>(new ArgumentException("Update failed as either loan number or folder id is invalid"));
            }
        }
        /// <summary>
        /// GetEventTypeList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventTypeEntity>> GetEventTypeList()
        {
            try
            {
                this._logger.LogInformation("GetEventTypeList() triggered to get event type master data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = EventRepositoryQueries.GetAllEventType;
                    IEnumerable<EventTypeEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<EventTypeEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetEventTypeList() in EventRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetEventActionList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventActionEntity>> GetEventActionList()
        {
            try
            {
                this._logger.LogInformation("GetEventActionList() triggered to get event action master data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = EventRepositoryQueries.GetAllEventAction;
                    IEnumerable<EventActionEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<EventActionEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetEventActionList() in EventRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetRelatedAsset
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="parcelId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RelatedAssetEntity>> GetRelatedAsset(string assetId, string parcelId)
        {
            try
            {
                this._logger.LogInformation("GetRelatedAsset() triggered to get related asset data by assetId and parcelId");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = EventRepositoryQueries.GetRelatedAsset;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_AssetId", assetId);
                    parameters.Add("@v_ParcelId", parcelId);
                    IEnumerable<RelatedAssetEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<RelatedAssetEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error found while executing GetRelatedAsset() in EventRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetContactByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContactEntity>> GetContactByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetContactByAssetId() triggered to get contact data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = EventRepositoryQueries.GetContactByAssetId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_AssetId", assetId);
                    IEnumerable<ContactEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<ContactEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetContactByAssetId() in EventRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// CreateEventId
        /// </summary>
        /// <param name="eventEntity"></param>
        /// <returns></returns>
        public async Task<int> CreateEventId(CreateEventCommand eventEntity)
        {
            try
            {
                this._logger.LogInformation("CreateEventId() to create an event by command");
                if (eventEntity.ActionCategory > 0 && eventEntity.ActionId > 0 && eventEntity.AssetId.Count > 0 
                    && eventEntity.EventTypeId > 0 && eventEntity.CreatedBy != null)
                {
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        string sp = EventRepositoryQueries.CreatedEvent;
                        var parameters = new DynamicParameters();
                        parameters.Add("@v_EventTypeId", eventEntity.EventTypeId);
                        parameters.Add("@v_ActionId", eventEntity.ActionId);
                        parameters.Add("@v_ActionCategory", eventEntity.ActionCategory);
                        parameters.Add("@v_EventDate", eventEntity.EventDate);
                        parameters.Add("@v_ContactId", eventEntity.ContactId);
                        parameters.Add("@v_Note", eventEntity.Note);
                        parameters.Add("@v_CreatedBy", eventEntity.CreatedBy);
                        parameters.Add("@v_AssetId", eventEntity.AssetId);
                        parameters.Add("@v_HighLightFlag", eventEntity.HighLightFlag);
                        // Added for User Initial
                        parameters.Add("@v_CreatedByUserInitial", eventEntity.CreatedByUserInitial);
                        parameters.Add("@v_UpdatedByUserInitial", eventEntity.UpdatedByUserInitial);

                        int result = 0;
                        if (_conn != null)
                            result = await conn.QueryFirstOrDefaultAsync<int>(sp, parameters, commandType: CommandType.StoredProcedure);
                        return result;
                    }
                }
                else
                {
                    this._logger.LogInformation("While executing CreateEventId() in EventRepository: Invalid Input parameter");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing CreateEventId() in EventRepository with Message" + ex.Message);
                throw;
            }

        }
        /// <summary>
        /// GetEventActionCategoryList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventActionCategoryEntity>> GetEventActionCategoryList()
        {
            try
            {
                this._logger.LogInformation("GetEventActionCategoryList() to get event action category master data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = EventRepositoryQueries.GetEventActionCategory;
                    IEnumerable<EventActionCategoryEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<EventActionCategoryEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetEventActionCategoryList() in EventRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetLienCountAssetDetails
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetStatus"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RelatedAssetEntity>> GetLienCountAssetDetails(string parcelId, string assetStatus)
        {
            try
            {
                this._logger.LogInformation("GetRelatedAsset() triggered to get related asset data by assetId and parcelId");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = EventRepositoryQueries.GetLienCountAssetDetails;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_ParcelId", parcelId);
                    parameters.Add("@v_Asset_Status", assetStatus);
                    var result = await connection.QueryAsync<RelatedAssetEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error found while executing GetRelatedAsset() in EventRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
