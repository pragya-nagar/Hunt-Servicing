using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nest;
using Services.Common.Constants;
using Services.ElasticSearch.Entity;
using Services.ElasticSearch.Repositories.Interfaces;
using Services.ElasticSearch.Services.Interfaces;

namespace Services.ElasticSearch.Services
{
    /// <summary>
    /// Search Service
    /// </summary>
    /// <seealso cref="IGlobalSearchService" />
    [ExcludeFromCodeCoverage]
    public class GlobalSearchService : IGlobalSearchService
    {
        /// <summary>
        /// The elastic client
        /// </summary>
        public IElasticClient _esClient { get; set; }

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The search repository
        /// </summary>
        private readonly ISearchRepository _searchRepository;

        /// <summary>
        /// Elastic search index name
        /// </summary>
        public string _esIndex { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalSearchService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="searchRepository">The search repository.</param>
        /// <param name="elasticClient">The elastic client.</param>
        public GlobalSearchService(ILogger<GlobalSearchService> logger, ISearchRepository searchRepository, IElasticClient elasticClient)
        {
            _logger = logger;
            _searchRepository = searchRepository;
            _esIndex = AppSettingConstants.ElsConfigGlobalIndex;
            _esClient = elasticClient;
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        public async Task Run()
        {
            try
            {
                var searchList = _searchRepository.GetGlobalSearchResult();
                if (searchList?.Result != null)
                {
                    if (_esClient.Indices.Exists(_esIndex).Exists)
                    {
                        var deleteResponse = _esClient.Indices.Delete(_esIndex);
                        if (deleteResponse.IsValid)
                        {
                            _logger.LogInformation(_esIndex + " deleted successfully.");
                        }
                    }

                    var createResponse = await _esClient.Indices.CreateAsync(_esIndex, c => c.Map<ElasticGlobalSearchEntity>(mp => mp.AutoMap()));
                    if (createResponse.IsValid)
                    {
                        _logger.LogInformation(_esIndex + " created successfully.");
                    }

                    foreach (var result in searchList.Result)
                    {
                        await _esClient.UpdateAsync(DocumentPath<ElasticGlobalSearchEntity>.Id(Guid.NewGuid().ToString("N")), u => u
                                             .Index(_esClient.ConnectionSettings.DefaultIndex)
                                             .DocAsUpsert()
                                             .Doc(result));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing Run() in AdvancedSearchService with Message" + ex.Message);
            }
        }
    }
}