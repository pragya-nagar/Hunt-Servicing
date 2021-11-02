using System.Threading.Tasks;

namespace Services.ElasticSearch.Services.Interfaces
{
    /// <summary>
    /// GlobalSearchService Interface
    /// </summary>
    public interface IGlobalSearchService
    {
        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns></returns>
        Task Run();
    }
}
