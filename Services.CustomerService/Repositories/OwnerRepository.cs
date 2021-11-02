
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel.OwnerViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Common.Constants;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// OwnerRepository
    /// </summary>
    public class OwnerRepository : IOwnerRepository
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
        public OwnerRepository(ILogger<OwnerRepository> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }
        /// <summary>
        /// GetOwnerListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OwnerEntity>> GetOwnerListByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetOwnerListByAssetId() triggered to get owner by assetId");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = OwnerServiceQueries.GetOwnerByAssetIdQuery;
                    var parameters = new DynamicParameters();
                    parameters.Add("@assetId", assetId, System.Data.DbType.String);
                    IEnumerable<OwnerEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<OwnerEntity>(sql, parameters);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetOwnerListByAssetId() in OwnerRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
