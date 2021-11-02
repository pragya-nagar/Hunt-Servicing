using Microsoft.Extensions.Logging;
using Moq;
using Nest;
using Services.CustomerService.Repositories;
using Services.CustomerService.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class SearchRepositoryTestCases
    {
        /// <summary>
        /// Gets the list default return elastic global search list.
        /// </summary>
        [Fact]
        public void GetList_Default_ReturnElasticGlobalSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);
            ISearchResponse<ElasticGlobalSearchEntity> elasticGlobalSearchEntityResponse = new SearchResponse<ElasticGlobalSearchEntity>();

            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticGlobalSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult(elasticGlobalSearchEntityResponse));

            //Act
            var result = searchRepository.GetList(string.Empty, string.Empty);

            //Assert
            Assert.IsType<List<ElasticGlobalSearchEntity>>(result.Result);
        }

        /// <summary>
        /// Gets the list default return NullReferenceException.
        /// </summary>
        [Fact]
        public async Task GetList_Default_ReturnNullReferenceException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);

            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticGlobalSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult((ISearchResponse<ElasticGlobalSearchEntity>)null));

            //Act, Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => searchRepository.GetList(string.Empty, string.Empty));
        }

        /// <summary>
        /// Gets the list by parcel identifier and asset identifier return elastic advanced search list.
        /// </summary>
        [Fact]
        public void GetList_ByParcelIdAndAssetId_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);
            ISearchResponse<ElasticAdvancedSearchEntity> elasticAdvancedSearchEntityResponse = new SearchResponse<ElasticAdvancedSearchEntity>();

            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticAdvancedSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult(elasticAdvancedSearchEntityResponse));

            //Act
            var result = searchRepository.GetListByParcelIdAndAssetId(string.Empty, string.Empty);

            //Assert
            Assert.IsType<List<ElasticAdvancedSearchEntity>>(result.Result);
        }

        /// <summary>
        /// Gets the list by parcel identifier and asset identifier return NullReferenceException.
        /// </summary>
        [Fact]
        public async Task GetList_ByParcelIdAndAssetId_ReturnNullReferenceException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);
            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticAdvancedSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult((ISearchResponse<ElasticAdvancedSearchEntity>)null));

            //Act, Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => searchRepository.GetListByParcelIdAndAssetId(string.Empty, string.Empty));
        }

        /// <summary>
        /// Gets the list by search text and state return elastic advanced search list.
        /// </summary>
        [Fact]
        public void GetList_BySearchTextAndState_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);
            ISearchResponse<ElasticAdvancedSearchEntity> elasticAdvancedSearchEntityResponse = new SearchResponse<ElasticAdvancedSearchEntity>();

            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticAdvancedSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult(elasticAdvancedSearchEntityResponse));

            //Act
            var result = searchRepository.GetListBySearchTextAndState(string.Empty, string.Empty);

            //Assert
            Assert.IsType<List<ElasticAdvancedSearchEntity>>(result.Result);
        }

        /// <summary>
        /// Gets the list by search text and state return NullReferenceException.
        /// </summary>
        [Fact]
        public async Task GetList_BySearchTextAndState_ReturnNullReferenceException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);
            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticAdvancedSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult((ISearchResponse<ElasticAdvancedSearchEntity>)null));

            //Act, Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => searchRepository.GetListBySearchTextAndState(string.Empty, string.Empty));
        }

        /// <summary>
        /// Gets the list by filters return elastic advanced search list.
        /// </summary>
        [Fact]
        public void GetList_ByFilters_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);
            ISearchResponse<ElasticAdvancedSearchEntity> elasticAdvancedSearchEntityResponse = new SearchResponse<ElasticAdvancedSearchEntity>();

            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticAdvancedSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult(elasticAdvancedSearchEntityResponse));

            //Act
            var result = searchRepository.GetListByFilters(new GlobalSearchOptionInputAdvancedEntity());

            //Assert
            Assert.IsType<List<ElasticAdvancedSearchEntity>>(result.Result);
        }

        /// <summary>
        /// Gets the list by filters return NullReferenceException.
        /// </summary>
        [Fact]
        public async Task GetList_ByFilters_ReturnNullReferenceException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIElasticClient = new Mock<IElasticClient>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIElasticClient.Object);
            mockIElasticClient.Setup(client => client.SearchAsync(
               It.IsAny<Func<SearchDescriptor<ElasticAdvancedSearchEntity>, ISearchRequest>>(), It.IsAny<CancellationToken>()
               )).Returns(Task.FromResult((ISearchResponse<ElasticAdvancedSearchEntity>)null));

            //Act, Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => searchRepository.GetListByFilters(new GlobalSearchOptionInputAdvancedEntity()));
        }
    }
}