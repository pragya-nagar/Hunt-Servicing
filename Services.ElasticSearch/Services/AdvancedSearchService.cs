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
    /// AdvancedSearch Service
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AdvancedSearchService : IAdvancedSearchService
    {
        /// <summary>
        /// The elastic client
        /// </summary>
        private readonly IElasticClient _esClient;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The global search repository
        /// </summary>
        private readonly ISearchRepository _searchRepository;

        /// <summary>
        /// Elastic search index name
        /// </summary>
        private readonly string _esIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedSearchService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="searchRepository">The search repository.</param>
        /// <param name="elasticClient">The elastic client.</param>
        public AdvancedSearchService(ILogger<AdvancedSearchService> logger, ISearchRepository searchRepository, IElasticClient elasticClient)
        {
            _logger = logger;
            _searchRepository = searchRepository;
            _esIndex = AppSettingConstants.ElsConfigAdvanceIndex;
            _esClient = elasticClient;
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        public async Task Run()
        {
            try
            {
                var searchList = _searchRepository.GetAdvancedSearchResult();
                if (searchList?.Result != null)
                {
                    if (_esClient.Indices.Exists(_esIndex).Exists)
                    {
                        var response = _esClient.Indices.Delete(_esIndex);
                        if (response.IsValid)
                        {
                            _logger.LogInformation(_esIndex + " deleted successfully.");
                        }
                    }

                    var createResponse = await _esClient.Indices.CreateAsync(_esIndex, c => c.Map<ElasticAdvancedSearchEntity>(mp => mp.AutoMap()));
                    if (createResponse.IsValid)
                    {
                        _logger.LogInformation(_esIndex + " created successfully.");
                    }

                    foreach (var result in searchList.Result)
                    {
                        await _esClient.UpdateAsync(DocumentPath<ElasticAdvancedSearchEntity>.Id(Guid.NewGuid().ToString("N")), u => u
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