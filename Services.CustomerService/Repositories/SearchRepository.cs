using Microsoft.Extensions.Logging;
using Nest;
using Services.Common.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// This class used as Search Repository.
    /// </summary>
    public class SearchRepository : ISearchRepository
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The elastic client
        /// </summary>
        private readonly IElasticClient _elasticClient;
        /// <summary>
        /// The advanced client
        /// </summary>
        private readonly string _advancedSearchIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRepository" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="elasticClient">The elastic client.</param>
        public SearchRepository(ILogger<SearchRepository> logger, IElasticClient elasticClient)
        {
            _logger = logger;
            _advancedSearchIndex = AppSettingConstants.ElsConfigAdvanceIndex;
            _elasticClient = elasticClient;
        }

        /// <summary>
        /// This method used to get auto search list.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns>ElasticGlobalSearchEntity list</returns>
        public async Task<IEnumerable<ElasticGlobalSearchEntity>> GetList(string searchText, string stateList)
        {
            try
            {
                searchText = string.IsNullOrEmpty(searchText) ? string.Empty : searchText.ToLower().Trim();

                stateList = (string.IsNullOrWhiteSpace(stateList)) ? string.Empty : stateList.ToLower();
                string[] stateIdArray = stateList.Split(",");

                var response = await _elasticClient.SearchAsync<ElasticGlobalSearchEntity>(s => s
                                                  .Query(q => q.Bool(b => b.Must(m => m.QueryString(d => d.Query(searchText + '*')))
                                                                             .Filter(f => f.Terms(t => t.Field(p => "asset-stateid").Terms(stateIdArray)))
                                                                       )
                                                          )
                                                 .Sort(so => so.Descending("asset-assetid"))
                                                 .From(0)
                                                 .Size(100));

                return response.Documents;
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing GetList() in SearchRepository with Message" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This method used to get auto search list.
        /// </summary>
        /// <param name="parcelId">The parcel identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        public async Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListByParcelIdAndAssetId(string parcelId, string assetId)
        {
            try
            {
                parcelId = string.IsNullOrEmpty(parcelId) ? string.Empty : parcelId.Trim();
                parcelId = parcelId.ToLower();

                assetId = string.IsNullOrEmpty(assetId) ? string.Empty : assetId.Trim();
                assetId = assetId.ToLower();

                var response = await _elasticClient.SearchAsync<ElasticAdvancedSearchEntity>(s => s.Index(_advancedSearchIndex)
                                                   .Query(q => q.Bool(b => b.Must(m => m.Term("asset-parcelid", parcelId),
                                                                                  m => m.Term("asset-assetid", assetId)))));

                return response.Documents;
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing GetListByParcelIdAndAssetId() in SearchRepository with Message" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This method used to get auto search list.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        public async Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListBySearchTextAndState(string searchText, string stateList)
        {
            try
            {
                searchText = string.IsNullOrEmpty(searchText) ? string.Empty : searchText.Trim();
                searchText = searchText.ToLower();

                stateList = (string.IsNullOrWhiteSpace(stateList)) ? string.Empty : stateList;
                string[] stateIdArray = stateList.Split(",");

                var response = await _elasticClient.SearchAsync<ElasticAdvancedSearchEntity>(s => s
                                                .Query(q => q.Bool(b => b.Must(m => m.QueryString(d => d.Query(searchText + '*')))
                                                        .Filter(f => f.Terms(t => t.Field(p => "asset-stateid").Terms(stateIdArray)))
                                                    )
                                                )
                                                .Sort(so => so.Descending("asset-assetid"))
                                                .From(0)
                                                .Size(100));

                return response.Documents;
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing GetListBySearchTextAndState() in SearchRepository with Message" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This method used to get auto search list.
        /// </summary>
        /// <param name="searchOptions">The search options.</param>
        /// <returns>ElasticGlobalSearchEntity list</returns>
        public async Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListByFilters(GlobalSearchOptionInputAdvancedEntity searchOptions)
        {
            try
            {
                var response = await _elasticClient.SearchAsync<ElasticAdvancedSearchEntity>
                                                                (s => s.Query(q => q.Bool(b => b.Must(m => m.Term("asset-parcelid", searchOptions?.AssetId?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-assetid", searchOptions?.OriAssetId?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-alternativeid", searchOptions?.AlternativeId?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-stateid", searchOptions?.StateId ?? 0),
                                                                                               m => m.Term("asset-jurisdication", searchOptions?.Jurisdication?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-assetstatusid", searchOptions?.AssetStatusId ?? 0),
                                                                                               m => m.Term("asset-lienhieraechy", searchOptions?.LienHieraechy?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-acquisationdate", searchOptions?.AcquisationDate ?? string.Empty),
                                                                                               m => m.Term("asset-ownername", searchOptions?.OwnerName?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-owneraddress", searchOptions?.OwnerAddress?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("property-propertyaddress", searchOptions?.PropertyAddress?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("property-parcelid", searchOptions?.ParcelID?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("property-alternativeparcelid1", searchOptions?.AlternativeParcelID1?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("property-alternativeparcelid2", searchOptions?.AlternativeParcelID2?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("property-alternativeparcelid3", searchOptions?.AlternativeParcelID3?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-certno", searchOptions?.CertNo?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-purchasingentity", searchOptions?.PurchasingEntity?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-currententity", searchOptions?.CurrentEntity?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-financialgroup", searchOptions?.FinancialGroup?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-attorneyname", searchOptions?.AttorneyName?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-contactname", searchOptions?.ContactName?.ToLower().Trim() ?? string.Empty),
                                                                                               m => m.Term("asset-contactphone", searchOptions?.ContactPhone?.ToLower().Trim() ?? string.Empty)
                                  ))));

                return response.Documents;
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing GetListByFilters() in SearchRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
