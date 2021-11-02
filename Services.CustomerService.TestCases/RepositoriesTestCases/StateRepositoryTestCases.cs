using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Repositories;
using Services.CustomerService.ViewModel;
using System;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class StateRepositoryTestCases
    {
        readonly StateRepository stateRepository;

        public StateRepositoryTestCases()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<StateRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            stateRepository = new StateRepository(mockLogger.Object, mockIConfiguration.Object);
        }

        [Fact]
        public void GetStateList_ByDefault_ReturnsStateListEntityList()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetStateList();

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetGlobalSearchOptionList_ByFilterValueAndInputStateList_ReturnsGlobalSearchOptionEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetGlobalSearchOptionList("","");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetAssetStatusList_ByDefault_ReturnsAssetStatusEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetAssetStatusList();

            //Assert
            Assert.Null(result.Result);
        }

        
        
        [Fact]
        public void GetGlobalPopUpSearchOptionList_ByParcelIdAndSearchValueAndStateList_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetGlobalPopUpSearchOptionListByParcelId("","","");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetGlobalPopUpSearchResult_ByParcelIdAndAssetIdAndSearchValue_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetGlobalPopUpSearchResultByParcelIdAndAssetId("","","");

            //Assert
            Assert.Null(result.Result);
        }
        
        [Fact]
        public void GetGlobalSearchOptionListAdvanced_ByGlobalSearchOptionInputAdvancedEntity_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            var globalSearchOptionInputAdvancedEntity = new GlobalSearchOptionInputAdvancedEntity()
            {
                AssetId = ""
            };
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetGlobalSearchOptionListAdvanced(globalSearchOptionInputAdvancedEntity);

            //Assert
            Assert.Null(result.Result);
        }
        
        [Fact]
        public void GetLienHeaderInfo_ByAssetId_ReturnsLienHeaderInfoEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetLienHeaderInfoByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }
        
        [Fact]
        public void GetLienAssetInfo_ByAssetId_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetLienAssetInfoByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetLienRecentActivity_ByAssetId_ReturnsLienRecentActivityEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetLienRecentActivityByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }
        
        [Fact]
        public void GetEventType_ByAssetId_ReturnsEventTypeEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetEventTypeByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetFlagAction_ByAssetId_ReturnsFlagActionEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetFlagActionByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetOtherAction_ByAssetId_ReturnsFlagActionEntity()
        {
            //Arrange
            stateRepository._conn = null;

            //Act
            var result = stateRepository.GetOtherActionByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }
        [Fact]
        public async System.Threading.Tasks.Task GetStateList_ByDefault_ReturnsStateListEntityListFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetStateList());
        }

        [Fact]
        public async System.Threading.Tasks.Task GetGlobalSearchOptionList_ByFilterValueAndInputStateList_ReturnsGlobalSearchOptionEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetGlobalSearchOptionList("", ""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAssetStatusList_ByDefault_ReturnsAssetStatusEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetAssetStatusList());
        }

        

        [Fact]
        public async System.Threading.Tasks.Task GetGlobalPopUpSearchOptionList_ByParcelIdAndSearchValueAndStateList_ReturnsSearchGridResponseEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetGlobalPopUpSearchOptionListByParcelId("", "", ""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetGlobalPopUpSearchResult_ByParcelIdAndAssetIdAndSearchValue_ReturnsSearchGridResponseEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetGlobalPopUpSearchResultByParcelIdAndAssetId("", "", ""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetGlobalSearchOptionListAdvanced_ByGlobalSearchOptionInputAdvancedEntity_ReturnsSearchGridResponseEntityFailure()
        {
            //Arrange
            var globalSearchOptionInputAdvancedEntity = new GlobalSearchOptionInputAdvancedEntity()
            {
                AssetId = ""
            };
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetGlobalSearchOptionListAdvanced(globalSearchOptionInputAdvancedEntity));
        }
        [Fact]
        public async System.Threading.Tasks.Task GetLienHeaderInfo_ByAssetId_ReturnsLienHeaderInfoEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetLienHeaderInfoByAssetId(""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetLienAssetInfo_ByAssetId_ReturnsSearchGridResponseEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetLienAssetInfoByAssetId(""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetLienRecentActivity_ByAssetId_ReturnsLienRecentActivityEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetLienRecentActivityByAssetId(""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetEventType_ByAssetId_ReturnsEventTypeEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetEventTypeByAssetId(""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetFlagAction_ByAssetId_ReturnsFlagActionEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetFlagActionByAssetId(""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetOtherAction_ByAssetId_ReturnsFlagActionEntityFailure()
        {
            //Arrange
            stateRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateRepository.GetOtherActionByAssetId(""));
        }
    }
}
