using System.Collections.Generic;
using System.Threading.Tasks;
using Services.ElasticSearch.Entity;

namespace Services.ElasticSearch.Repositories.Interfaces
{
    /// <summary>
    /// GlobalSearchRepository Interface
    /// </summary>
    public interface ISearchRepository
    {
        /// <summary>
        /// Gets the search result.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ElasticGlobalSearchEntity>> GetGlobalSearchResult();

        /// <summary>
        /// Gets the advance search result.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ElasticAdvancedSearchEntity>> GetAdvancedSearchResult();
    }
}
