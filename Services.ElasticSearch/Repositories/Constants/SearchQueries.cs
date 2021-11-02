using System.Diagnostics.CodeAnalysis;

namespace Services.ElasticSearch.Repositories.Constants
{
    /// <summary>
    /// GlobalSearch Queries
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class SearchQueries
    {
        /// <summary>
        /// The get global result
        /// </summary>
        public const string GetGlobalResult = "SELECT * FROM public.vw_globalsearchresult";
        /// <summary>
        /// The get advance search result
        /// </summary>
        public const string GetAdvancedSearchResult = "SELECT * FROM public.vw_advancesearchresult";
    }
}
