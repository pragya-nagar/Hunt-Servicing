using Services.CustomerService.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Services.Interfaces
{
    /// <summary>
    /// Search Service Interface
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// This method used to get auto search list.
        /// </summary>
        /// <param name="searchText">The search value.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns>ElasticGlobalSearchEntity list</returns>
        Task<IEnumerable<ElasticGlobalSearchEntity>> GetList(string searchText, string stateList);

        /// <summary>
        /// This method used to get list based on parcelId and assetId.
        /// </summary>
        /// <param name="parcelId">The parcel identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListByParcelIdAndAssetId(string parcelId, string assetId);

        /// <summary>
        /// This method used to get list based on search text and state values.
        /// </summary>
        /// <param name="searchText">The search value.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListBySearchTextAndState(string searchText, string stateList);

        /// <summary>
        /// This method used to get list with all selected filters.
        /// </summary>
        /// <param name="searchOptions">The global search option input advanced entity.</param>
        /// <returns>ElasticAdvancedSearchEntity list</returns>
        Task<IEnumerable<ElasticAdvancedSearchEntity>> GetListByFilters(GlobalSearchOptionInputAdvancedEntity searchOptions);
    }
}
