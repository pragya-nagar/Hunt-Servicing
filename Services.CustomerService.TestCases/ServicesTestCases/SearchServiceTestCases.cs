using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.Services.Classes;
using Services.CustomerService.TestCases.MockData;
using Services.CustomerService.ViewModel;
using Xunit;

namespace Services.CustomerService.TestCases.ServicesTestCases
{
    public class SearchServiceTestCases
    {
        /// <summary>
        /// Gets the list default return elastic global search list.
        /// </summary>
        [Fact]
        public void GetList_Default_ReturnElasticGlobalSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchService>>();
            var mockISearchRepository = new Mock<ISearchRepository>();
            var searchService = new SearchService(mockLogger.Object, mockISearchRepository.Object);

            mockISearchRepository.Setup(repo => repo.GetList(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockSearchService.MockGlobalSearchEntity);
            //Act
            var result = searchService.GetList(string.Empty, string.Empty).Result.ToList();

            //Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Gets the list by parcel identifier and asset identifier return elastic advanced search list.
        /// </summary>
        [Fact]
        public void GetList_ByParcelIdAndAssetId_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchService>>();
            var mockISearchRepository = new Mock<ISearchRepository>();
            var searchService = new SearchService(mockLogger.Object, mockISearchRepository.Object);

            mockISearchRepository.Setup(repo => repo.GetListByParcelIdAndAssetId(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockSearchService.MockAdvancedSearchEntity);
            //Act
            var result = searchService.GetListByParcelIdAndAssetId(string.Empty, string.Empty).Result.ToList();

            //Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Gets the list by search text and state return elastic advanced search list.
        /// </summary>
        [Fact]
        public void GetList_BySearchTextAndState_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchService>>();
            var mockISearchRepository = new Mock<ISearchRepository>();
            var searchService = new SearchService(mockLogger.Object, mockISearchRepository.Object);

            mockISearchRepository.Setup(repo => repo.GetListBySearchTextAndState(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockSearchService.MockAdvancedSearchEntity);
            //Act
            var result = searchService.GetListBySearchTextAndState(string.Empty, string.Empty).Result.ToList();

            //Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Gets the list by filters return elastic advanced search list.
        /// </summary>
        [Fact]
        public void GetList_ByFilters_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchService>>();
            var mockISearchRepository = new Mock<ISearchRepository>();
            var searchService = new SearchService(mockLogger.Object, mockISearchRepository.Object);

            mockISearchRepository.Setup(repo => repo.GetListByFilters(It.IsAny<GlobalSearchOptionInputAdvancedEntity>())).ReturnsAsync(MockSearchService.MockAdvancedSearchEntity);
            //Act
            var result = searchService.GetListByFilters(new GlobalSearchOptionInputAdvancedEntity()).Result.ToList();

            //Assert
            Assert.NotNull(result);
        }
    }
}
