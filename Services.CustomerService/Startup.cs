using Amazon.S3;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services.Common.Classes;
using Services.Common.S3Management;
using Services.CustomerService.Repositories;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.Services.Classes;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.Validator;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Services.Common.Logging.CloudWatch;
using Services.Common.Logging.Middleware;
using Services.Common.S3Management.Interfaces;

namespace Services.CustomerService
{
    /// <summary>
    /// Startup
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Startup> _logger;
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSerilogLogging(_configuration);
            this._logger.LogInformation("Service configuration started...");

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation(
                i =>
                    {
                        i.RegisterValidatorsFromAssemblyContaining<CreateContactCommandValidator>();
                        i.RegisterValidatorsFromAssemblyContaining<CreateEventCommandValidator>();
                        i.RegisterValidatorsFromAssemblyContaining<CreateDocumentCommandValidator>();

                        i.RegisterValidatorsFromAssemblyContaining<UpdateContactCommandValidator>();
                        i.RegisterValidatorsFromAssemblyContaining<GlobalSearchOptionInputAdvancedEntityValidator>();

                        i.RegisterValidatorsFromAssemblyContaining<RemoveUploadFileFlagCommandValidator>();
                    }
                );

            services.AddRunTimeContext();
            
            services.AddTransient<IAmazonS3>(_ => new AmazonS3Client(_configuration.GetRegionEndPoint()));
            services.AddTransient<IFileManagement, FileManagement>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<ICustomerSupportService, CustomerSupportService>();
            services.AddTransient<ICustodianSupportService, CustodianSupportService>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<ISearchRepository, SearchRepository>();
            services.AddTransient<IEventAssetRepository, EventAssetRepository>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<ICertificateUploadFileRepository, CertificateUploadFileRepository>();
            services.ConfigureElasticSearch(_configuration);            

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CustomerSupport API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //... and tell Swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath);
            });

            services.AddHealthChecks();
            services.AddRunTimeContext();

            this._logger.LogInformation("Service configuration completed.");
        }
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHealthChecks("/api/health");

            app.UseVersion();
            app.UseMvc();
            app.UseSwagger();
            // Enable middle-ware to serve swagger-UI (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Post API V1");
            });

            app.UseCorrelationLogging();
        }
    }
}
