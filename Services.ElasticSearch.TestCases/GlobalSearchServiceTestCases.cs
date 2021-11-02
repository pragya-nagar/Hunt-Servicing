using Microsoft.Extensions.Logging;
using Moq;
using Nest;
using Services.ElasticSearch.Repositories.Interfaces;
using Services.ElasticSearch.Services;
using Services.ElasticSearch.TestCases.MockData;
using Xunit;

namespace Services.ElasticSearch.TestCases
{
    public class GlobalSearchServiceTestCases
    {
        /// <summary>
        /// Gets the list default return elastic global search list.
        /// </summary>
        [Fact]
        public void GetGlobalSearchResult_Default_ReturnElasticGlobalSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<GlobalSearchService>>();
            var mockISearchRepository = new Mock<ISearchRepository>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var globalSearchService = new GlobalSearchService(mockLogger.Object, mockISearchRepository.Object, mockIElasticClient.Object);

            mockISearchRepository.Setup(repo => repo.GetGlobalSearchResult()).ReturnsAsync(MockSearchService.MockGlobalSearchEntity);
            //Act
            var result = globalSearchService.Run();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAdvancedSearchResult_Default_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<GlobalSearchService>>();
            var mockISearchRepository = new Mock<ISearchRepository>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var globalSearchService = new GlobalSearchService(mockLogger.Object, mockISearchRepository.Object, mockIElasticClient.Object);

            mockISearchRepository.Setup(repo => repo.GetAdvancedSearchResult()).ReturnsAsync(MockSearchService.MockAdvancedSearchEntity);
            //Act
            var result = globalSearchService.Run();

            //Assert
            Assert.NotNull(result);
        }
    }
}
