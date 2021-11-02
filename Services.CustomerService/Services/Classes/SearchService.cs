using Microsoft.Extensions.Logging;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Services.Classes
{
    /// <summary>
    /// This class used as service for search.
    /// </summary>
    public class SearchService : ISearchService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The search repository
        /// </summary>
        private readonly ISearchRepository _ISearchRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="searchRepository">The search repository.</param>
        public SearchService(ILogger<SearchService> logger, ISearchRepository searchRepository)
        {
            _logger = logger;
            _ISearchRepository = searchRepository;
        }

        /// <summary>
        /// This method used to get auto search list.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns>ElasticGlobalSearchEntity list</returns>
        public async Task<IEnumerable<ElasticGlobalSearchEntity>> GetList(string searchText, string stateList)
        {
            _logger.LogInformation("GetList() triggered to get list of asset");
            return await _ISearchRepository.GetList(searchText, stateList);
        }

        /// <summary>
        /// This method used to get list based parcelId and assetId.
        /// </summary>
        /// <param name="parcelId">The parcel identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        public async Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListByParcelIdAndAssetId(string parcelId, string assetId)
        {
            _logger.LogInformation("GetListByParcelIdAndAssetId() triggered to get list of asset");
            return await _ISearchRepository.GetListByParcelIdAndAssetId(parcelId, assetId);
        }

        /// <summary>
        /// This method used to get list based on search text and state values.
        /// </summary>
        /// <param name="searchText">The search value.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        public async Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListBySearchTextAndState(string searchText, string stateList)
        {
            _logger.LogInformation("GetListBySearchTextAndState() triggered to get list of asset");
            return await _ISearchRepository.GetListBySearchTextAndState(searchText, stateList);
        }

        /// <summary>
        /// This method used to get list with all selected filters.
        /// </summary>
        /// <param name="searchOptions">The global search option input advanced entity.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        public async Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListByFilters(GlobalSearchOptionInputAdvancedEntity searchOptions)
        {
            _logger.LogInformation("GetListByFilters() triggered to get list of asset");
            return await _ISearchRepository.GetListByFilters(searchOptions);
        }
    }
}
