using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.Common.Constants;
using Services.ElasticSearch.Entity;
using Services.ElasticSearch.Repositories.Constants;
using Services.ElasticSearch.Repositories.Interfaces;

namespace Services.ElasticSearch.Repositories
{
    /// <summary>
    /// GlobalSearch Repository
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SearchRepository : ISearchRepository
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The connection
        /// </summary>
        public string _conn { get; set; }

        /// <summary>
        /// StateRepository
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        public SearchRepository(ILogger<SearchRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }

        /// <summary>
        /// Get the global search result.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ElasticGlobalSearchEntity>> GetGlobalSearchResult()
        {
            try
            {
                _logger.LogInformation("GetGlobalSearchResult() triggered to get search data");
                using (var connection = new NpgsqlConnection(_conn))
                {
                    var sql = SearchQueries.GetGlobalResult;
                    IEnumerable<ElasticGlobalSearchEntity> result = null;
                    if (this._conn != null)
                        result = await connection.QueryAsync<ElasticGlobalSearchEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing GetGlobalSearchResult() in SearchRepository with Message" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Get the global search result.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ElasticAdvancedSearchEntity>> GetAdvancedSearchResult()
        {
            try
            {
                _logger.LogInformation("GetAdvancedSearchResult() triggered to get search data");
                using (var connection = new NpgsqlConnection(_conn))
                {
                    var sql = SearchQueries.GetAdvancedSearchResult;
                    IEnumerable<ElasticAdvancedSearchEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<ElasticAdvancedSearchEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing GetAdvancedSearchResult() in SearchRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
