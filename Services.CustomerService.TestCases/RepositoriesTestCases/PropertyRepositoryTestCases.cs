
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Repositories;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class PropertyRepositoryTestCases
    {
        [Fact]
        public void GetPropertyInfo_ByAssetId_ReturnsPropertyListEntity()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<PropertyRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var propertyRepository = new PropertyRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = null };


            //Act
            var result = propertyRepository.GetPropertyInfoByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }
        [Fact]
        public void GetPropertyList_ByAssetId_ReturnsPropertyListEntity()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<PropertyRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var propertyRepository = new PropertyRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = null };


            //Act
            var result = propertyRepository.GetPropertyListByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }
        [Fact]
        public async System.Threading.Tasks.Task GetPropertyInfo_ByAssetId_ReturnsArgumentException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<PropertyRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var propertyRepository = new PropertyRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => propertyRepository.GetPropertyInfoByAssetId(""));
        }


        [Fact]
        public async System.Threading.Tasks.Task GetPropertyList_ByAssetId_ReturnsArgumentException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<PropertyRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var propertyRepository = new PropertyRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => propertyRepository.GetPropertyListByAssetId(""));
        }
    }
}
