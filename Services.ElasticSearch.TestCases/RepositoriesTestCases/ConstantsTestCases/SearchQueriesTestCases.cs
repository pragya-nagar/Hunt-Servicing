using Services.ElasticSearch.Repositories.Constants;
using Xunit;

namespace Services.ElasticSearch.TestCases.RepositoriesTestCases.ConstantsTestCases
{
    public class SearchQueriesTestCases
    {
        [Fact]
        public void GetAdvancedSearchResultGetPropertyTests()
        {
            var query = SearchQueries.GetAdvancedSearchResult;
            Assert.True(query.Length > 0);
        }

        [Fact]
        public void GetGlobalResultGetPropertyTests()
        {
            var query = SearchQueries.GetGlobalResult;
            Assert.True(query.Length > 0);
        }
    }
}
