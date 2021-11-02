using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.ElasticSearch.Repositories;
using System;
using Xunit;

namespace Services.ElasticSearch.TestCases.RepositoriesTestCases
{
    public class SearchRepositoryTestCases
    {
        /// <summary>
        /// Gets the list default return elastic global search list.
        /// </summary>
        [Fact]
        public void GlobalSearchResult_ReturnElasticGlobalSearchEntityList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = null };

            //Act
            var result = searchRepository.GetGlobalSearchResult();

            //Assert
            Assert.Null(result.Result);
        }

        /// <summary>
        /// Gets the list default return elastic global search list.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task GlobalSearchResult_ReturnArgumentException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => searchRepository.GetGlobalSearchResult());
        }

        [Fact]
        public void AdvancedSearchResult_ReturnElasticAdvancedSearchList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = null };

            //Act
            var result = searchRepository.GetAdvancedSearchResult();

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task AdvancedSearchResult_ReturnArgumentException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<SearchRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var searchRepository = new SearchRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => searchRepository.GetAdvancedSearchResult());
        }
    }
}