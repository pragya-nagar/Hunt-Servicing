using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Services.ElasticSearch.Services.Interfaces;

namespace Services.ElasticSearch
{
    /// <summary>
    /// Elastic Search
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ElasticSearch : BackgroundService
    {
        /// <summary>
        /// The global search service
        /// </summary>
        private readonly IGlobalSearchService _globalSearchService;

        /// <summary>
        /// The advance search service
        /// </summary>
        private readonly IAdvancedSearchService _advancedSearchService;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticSearch" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="globalSearchService">The global search service.</param>
        /// <param name="advancedSearchService">The advance search service.</param>
        public ElasticSearch(ILogger<ElasticSearch> logger, IGlobalSearchService globalSearchService, IAdvancedSearchService advancedSearchService)
        {
            _logger = logger;
            _globalSearchService = globalSearchService;
            _advancedSearchService = advancedSearchService;
        }

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" /> starts. The implementation should return a task that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.</param>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ElasticSearch Service is starting at : " + DateTime.Now);

            await _globalSearchService.Run();
            await _advancedSearchService.Run();

            _logger.LogInformation("ElasticSearch service is stopping at : " + DateTime.Now);
        }
    }
}
