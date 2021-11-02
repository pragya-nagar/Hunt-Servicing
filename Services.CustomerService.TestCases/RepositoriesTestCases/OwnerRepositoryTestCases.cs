using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Repositories;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    [ExcludeFromCodeCoverage]
    public class OwnerRepositoryTestCases
    {
        [Fact]
        public void GetStateList_ByDefault_ReturnsStateListEntityList()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<OwnerRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var ownerRepository = new OwnerRepository(mockLogger.Object, mockIConfiguration.Object) {_conn = null};


            //Act
            var result = ownerRepository.GetOwnerListByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }
        [Fact]
        public async System.Threading.Tasks.Task GetStateList_ByDefault_ReturnsArgumentException()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<OwnerRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            var ownerRepository = new OwnerRepository(mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => ownerRepository.GetOwnerListByAssetId(""));
        }
    }
}
