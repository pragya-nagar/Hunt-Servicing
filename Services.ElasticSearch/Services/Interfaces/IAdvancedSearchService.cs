using System.Threading.Tasks;

namespace Services.ElasticSearch.Services.Interfaces
{
    /// <summary>
    /// AdvancedSearchService Interface
    /// </summary>
    public interface IAdvancedSearchService
    {
        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns></returns>
        Task Run();
    }
}
