using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel.PropertyViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Common.Constants;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// PropertyRepository
    /// </summary>
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ILogger _logger;
        /// <summary>
        /// _conn
        /// </summary>
        public string _conn { get; set; }
        /// <summary>
        /// PropertyRepository
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public PropertyRepository(ILogger<PropertyRepository> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }
        /// <summary>
        /// GetPropertyInfoByParcelId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyDetailsEntity>> GetPropertyInfoByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetContactListByAssetId() triggered to get contact master data ");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = PropertyRepositoryConstant.GetParcelInfoByAssetId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@assetId", assetId, System.Data.DbType.String);
                    IEnumerable<PropertyDetailsEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<PropertyDetailsEntity>(sql, parameters);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetPropertyInfoByParcelId() in PropertyRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetPropertyListByAssetId
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyDetailsEntity>> GetPropertyListByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetDocumentType() ");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = PropertyRepositoryConstant.GetPropertyListByAssetId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@assetId", assetId, System.Data.DbType.String);
                    IEnumerable<PropertyDetailsEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<PropertyDetailsEntity>(sql, parameters);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetPropertyListByAssetId() in PropertyRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
