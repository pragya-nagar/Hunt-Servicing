using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using Services.ElasticSearch.Repositories;
using Services.ElasticSearch.Repositories.Interfaces;
using Services.ElasticSearch.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Services.Common.Classes;
using Services.ElasticSearch.Services;

namespace Services.ElasticSearch
{
    /// <summary>
    /// This is used when application Start
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Startup> _logger;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("Elastic Search Configuration Started: " + DateTime.Now);
            services.AddSingleton<IGlobalSearchService, GlobalSearchService>();
            services.AddSingleton<IAdvancedSearchService, AdvancedSearchService>();
            services.AddSingleton<ISearchRepository, SearchRepository>();

            services.ConfigureElasticSearch(_configuration);
            services.AddHostedService<ElasticSearch>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middle-ware layer if any and we can set configuration things.
        }
    }
}
