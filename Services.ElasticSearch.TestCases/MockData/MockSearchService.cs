using System.Collections.Generic;
using Services.ElasticSearch.Entity;

namespace Services.ElasticSearch.TestCases.MockData
{
    public static class MockSearchService
    {
        /// <summary>
        /// Mocks the global search entity.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ElasticGlobalSearchEntity> MockGlobalSearchEntity()
        {
            yield return new ElasticGlobalSearchEntity
            {
                AssetId = "FL19000095CC",
                ParcelId = "B02 00129 0013"
            };
        }

        /// <summary>
        /// Mocks the advanced search entity.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ElasticAdvancedSearchEntity> MockAdvancedSearchEntity()
        {
            yield return new ElasticAdvancedSearchEntity
            {
                AssetId = "FL19000095CC",
                ParcelId = "B02 00129 0013"
            };
        }
    }
}
