using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.CustomerService.Controllers;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.TestCases.MockData;
using Services.CustomerService.ViewModel;
using Xunit;

namespace Services.CustomerService.TestCases.ControllerTestCases
{
    public class SearchControllerTestCases
    {
        /// <summary>
        /// Searches the default return elastic global search list.
        /// </summary>
        [Fact]
        public void Search_Default_ReturnElasticGlobalSearchList()
        {
            //Arrange
            var mockSearchService = new Mock<ISearchService>();
            var searchController = new SearchController(mockSearchService.Object);
            mockSearchService.Setup(repo => repo.GetList(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockSearchService.MockGlobalSearchEntity);
           
            //Act
            var result = searchController.Search(string.Empty, string.Empty);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.Result).StatusCode);
            Assert.NotNull((OkObjectResult)result.Result);
        }

        /// <summary>
        /// Searches the by parcel identifier and asset identifier return elastic advanced search list.
        /// </summary>
        [Fact]
        public void Search_ByParcelIdAndAssetId_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockSearchService = new Mock<ISearchService>();
            var searchController = new SearchController(mockSearchService.Object);
            mockSearchService.Setup(repo => repo.GetListByParcelIdAndAssetId(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockSearchService.MockAdvancedSearchEntity());
           
            //Act
            var result = searchController.SearchByParcelIdAndAssetId(string.Empty, string.Empty);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.Result).StatusCode);
            Assert.NotNull((OkObjectResult)result.Result);
        }

        /// <summary>
        /// Searches the advanced return elastic advanced search list.
        /// </summary>
        [Fact]
        public void Search_Advanced_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockSearchService = new Mock<ISearchService>();
            var searchController = new SearchController(mockSearchService.Object);
            mockSearchService.Setup(repo => repo.GetListBySearchTextAndState(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockSearchService.MockAdvancedSearchEntity);
           
            //Act
            var result = searchController.AdvancedSearch(string.Empty, string.Empty);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.Result).StatusCode);
            Assert.NotNull((OkObjectResult)result.Result);
        }

        /// <summary>
        /// Searches the advanced with filter return elastic advanced search list.
        /// </summary>
        [Fact]
        public void Search_AdvancedWithFilter_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockSearchService = new Mock<ISearchService>();
            var searchController = new SearchController(mockSearchService.Object);

            mockSearchService.Setup(repo => repo.GetListByFilters(It.IsAny<GlobalSearchOptionInputAdvancedEntity>())).ReturnsAsync(MockSearchService.MockAdvancedSearchEntity);
            //Act
            var result = searchController.AdvancedSearchWithFilters(new GlobalSearchOptionInputAdvancedEntity());

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.Result).StatusCode);
            Assert.NotNull((OkObjectResult)result.Result);
        }
    }
}
