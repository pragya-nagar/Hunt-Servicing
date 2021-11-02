using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Services.Common.Constants;
using Services.CustomerService.ViewModel.EventAssetViewModel;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// EventAssetRepository
    /// </summary>
    public class EventAssetRepository : IEventAssetRepository
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
        public EventAssetRepository(ILogger<EventAssetRepository> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }
        /// <summary>
        /// GetRejectReasonList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventMasterRejectionReasonEntity>> GetRejectReasonList()
        {
            try
            {
                this._logger.LogInformation("GetRejectReasonList() triggered to get Reject Reason List");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = PendingEventsQueries.GetRejectReason;
                    IEnumerable<EventMasterRejectionReasonEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<EventMasterRejectionReasonEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetRejectReasonList() in EventRepository with Message" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// GetPendingEvents
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventMasterEntity>> GetEventMaster(int eventMasterStatusId)
        {
            try
            {
                this._logger.LogInformation("GetRejectReasonList() triggered to get Reject Reason List");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = PendingEventsQueries.GetMasterEvents;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_EventMasterStatusId", eventMasterStatusId);

                    IEnumerable<EventMasterEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<EventMasterEntity>(sql, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetRejectReasonList() in EventRepository with Message" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// RejectedEventsAction
        /// </summary>
        /// <returns></returns>
        public async Task<int> RejectedEventsAction(RejectedEventsActionCommand rejectedEventsActionCommand)
        {
            int resultSum = 0;
            try
            {
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    if (rejectedEventsActionCommand.DeletedList != null && rejectedEventsActionCommand.DeletedList.Length > 0)
                    {
                        int result = await DeleteEventMaster(rejectedEventsActionCommand.DeletedList, connection);
                        resultSum += result;
                    }
                    if (rejectedEventsActionCommand.PendingList != null && rejectedEventsActionCommand.PendingList.Length > 0)
                    {
                        int result = await PendingEventMaster(rejectedEventsActionCommand.PendingList, connection);
                        resultSum += result;
                    }
                    if (rejectedEventsActionCommand.ApprovedList != null && rejectedEventsActionCommand.ApprovedList.Length > 0)
                    {
                        int result = await ApprovedEventMaster(rejectedEventsActionCommand.ApprovedList, connection);
                        resultSum += result;
                    }
                    if (rejectedEventsActionCommand.RejectedList != null && rejectedEventsActionCommand.RejectedList.Count > 0)
                    {
                        int result = await RejectedEventMaster(rejectedEventsActionCommand.RejectedList, connection);
                        resultSum += result;
                    }
                }
                return resultSum;
            }
            catch (Exception ex)
            {

                this._logger.LogError("Run time error while executing RejectedEventsAction() in EventRepository with Message" + ex.Message);
                throw;
            }

        }
        /// <summary>
        /// DeleteEventMaster
        /// </summary>
        /// <param name="deletedList"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<int> DeleteEventMaster(int[] deletedList, NpgsqlConnection connection)
        {
            this._logger.LogInformation("RejectedEventsAction() triggered to update delete flag");
            int result = 0;

            var sql = PendingEventsQueries.RemoveEventMaster;
            var parameters = new DynamicParameters();

            foreach (var item in deletedList)
            {
                parameters.Add("@eventMasterId", item);
                result += _conn != null ? await connection.ExecuteAsync(sql, parameters) : 0;

            }
            return result;
        }
        /// <summary>
        /// PendingEventMaster
        /// </summary>
        /// <param name="pendingList"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<int> PendingEventMaster(int[] pendingList, NpgsqlConnection connection)
        {
            this._logger.LogInformation("RejectedEventsAction() triggered to update Pending flag");
            int result = 0;

            var sql = PendingEventsQueries.ModifyEventMasterFromRejectedToPending;
            var parameters = new DynamicParameters();

            foreach (var item in pendingList)
            {
                parameters.Add("@eventMasterId", item);
                result += _conn != null ? await connection.ExecuteAsync(sql, parameters) : 0;
            }
            return result;
        }
        /// <summary>
        /// ApprovedEventMaster
        /// </summary>
        /// <param name="approvedList"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<int> ApprovedEventMaster(int[] approvedList, NpgsqlConnection connection)
        {
            this._logger.LogInformation("RejectedEventsAction() triggered to update Pending flag");
            int result = 0;

            var sql = PendingEventsQueries.ApprovedEventMaster;
            var parameters = new DynamicParameters();

            foreach (var item in approvedList)
            {
                parameters.Add("@eventMasterId", item);
                result += _conn != null ? await connection.ExecuteAsync(sql, parameters) : 0;
            }
            return result;
        }
        /// <summary>
        /// RejectedEventMaster
        /// </summary>
        /// <param name="rejectedList"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<int> RejectedEventMaster(List<RejectedListProp> rejectedList, NpgsqlConnection connection)
        {
            this._logger.LogInformation("RejectedEventsAction() triggered to update Pending flag");
            int result = 0;

            var sql = PendingEventsQueries.RejectedEventMaster;
            var parameters = new DynamicParameters();

            foreach (var item in rejectedList)
            {
                parameters.Add("@eventMasterId", item.EventMasterId);
                parameters.Add("@rejectedReason", item.RejectedReason);
                result += _conn != null ? await connection.ExecuteAsync(sql, parameters) : 0;
            }
            return result;
        }

        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventDetailsHeaderEntity>> EventDetailsHeader(string eventId)
        {
            try
            {
                this._logger.LogInformation("EventDetailsHeaderEntity() triggered to grab data");
                using (var connection = new NpgsqlConnection(_conn))
                {
                    var sql = PendingEventsQueries.EventDetailsHeaderQuery;
                    var parameters = new DynamicParameters();
                    parameters.Add("@eventId", eventId);
                    var result = _conn != null ? await connection.QueryAsync<EventDetailsHeaderEntity>(sql, parameters) : null;
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing EventDetails() in EventDetailsHeader with Message" + ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// EventDetails
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventDetailsEntity>> EventDetails(string eventId)
        {
            try
            {
                this._logger.LogInformation("EventDetailsHeaderEntity() triggered to grab data");
                using (var connection = new NpgsqlConnection(_conn))
                {
                    var sql = PendingEventsQueries.EventDetailsQuery;
                    var parameters = new DynamicParameters();
                    parameters.Add("@eventId", eventId);
                    var result = _conn != null ? await connection.QueryAsync<EventDetailsEntity>(sql, parameters) : null;
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing EventDetails() in EventRepository with Message" + ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// EventDetailsAssetList
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventTypeAssetDetailsEntity>> EventDetailsAssetList(string eventId)
        {
            try
            {
                this._logger.LogInformation("EventDetailsHeaderEntity() triggered to grab data");
                using (var connection = new NpgsqlConnection(_conn))
                {
                    var sql = PendingEventsQueries.EventDetailsAssetListQuery;
                    var parameters = new DynamicParameters();
                    parameters.Add("@eventId", eventId);
                    var result = _conn != null ? await connection.QueryAsync<EventTypeAssetDetailsEntity>(sql, parameters) : null;
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing EventDetailsHeaderEntity() in EventRepository with Message" + ex.Message);
                throw;
            }
            
        }
    }
}
