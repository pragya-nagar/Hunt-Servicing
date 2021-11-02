using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.Services.Classes;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.TestCases.MockData;
using Services.CustomerService.ViewModel;
using System.Linq;
using Xunit;

namespace Services.CustomerService.TestCases.ServicesTestCases
{
    public class CustomerSupportServiceTestCases
    {
        private readonly Mock<IStateRepository> mockStateRepository;
        private readonly Mock<IEventRepository> mockEventRepository;
        private readonly Mock<IOwnerRepository> mockOwnerRepository;
        private readonly Mock<IContactRepository> mockContactRepository;
        private readonly Mock<IPropertyRepository> mockPropertyRepository;
        private readonly Mock<IDocumentRepository> mockDocumentRepository;
        private readonly ICustomerSupportService customerSupportService;

        public CustomerSupportServiceTestCases()
        {
            mockStateRepository = new Mock<IStateRepository>();
            mockEventRepository = new Mock<IEventRepository>();
            mockOwnerRepository = new Mock<IOwnerRepository>();
            mockContactRepository = new Mock<IContactRepository>();
            mockPropertyRepository = new Mock<IPropertyRepository>();
            mockDocumentRepository = new Mock<IDocumentRepository>();
            var mockLogger = new Mock<ILogger<ICustomerSupportService>>();
            customerSupportService = new CustomerSupportService(mockDocumentRepository.Object, mockPropertyRepository.Object, mockContactRepository.Object, mockOwnerRepository.Object, mockStateRepository.Object, mockEventRepository.Object, mockLogger.Object);
        }

        [Fact]
        public void GetListAsyncData_ByDefault_ReturnsStateListEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetStateList()).ReturnsAsync(MockCustomerService.MockStateList);
            //Act
            var result = customerSupportService.GetListAsync().Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("TA", result[0].StateCode);
            Assert.Equal("Texas", result[0].StateName);
            Assert.Equal(1, result[0].StateId);
        }

        [Fact]
        public void GetAssetStatusListAsyncData_ByDefault_ReturnsAssetStatusEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetAssetStatusList()).ReturnsAsync(MockCustomerService.MockAssetStatusList);
            //Act
            var result = customerSupportService.GetAssetStatusListAsync().Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("ACTIVE", result[0].StatusCode);
            Assert.Equal("ACTIVE", result[0].StatusName);
            Assert.Equal(1, result[0].StatusId);
        }

        [Fact]
        public void GetGlobalSearchOptionListData_ByFilterValueAndParStateList_ReturnsGlobalSearchOptionEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetGlobalSearchOptionList(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockGlobalSearchOptionEntity);

            //Act
            var result = customerSupportService.GetGlobalSearchOptionList("", "").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("00 00 0000", result[0].CellPhone);
            Assert.Equal("Test", result[0].ContactPerson);
        }

        

        [Fact]
        public void GetGlobalPopUpSearchOptionListData_ByParcelIdAndSearchValue_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetGlobalPopUpSearchOptionListByParcelId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockSearchGridResponseEntity);

            //Act
            var result = customerSupportService.GetGlobalPopUpSearchOptionListByParcelId("", "", "").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].NumberOfLienCountActive);
            Assert.Equal(0, result[0].NumberOfLienCountRedeemed);
        }

        [Fact]
        public void GetGlobalSearchOptionListAdvancedData_ByGlobalSearchOptionInputAdvancedEntity_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            var globalSearchOptionInputAdvancedEntity = new GlobalSearchOptionInputAdvancedEntity()
            {
                AssetId = "0"
            };

            mockStateRepository.Setup(repo => repo.GetGlobalSearchOptionListAdvanced(It.IsAny<GlobalSearchOptionInputAdvancedEntity>())).ReturnsAsync(MockCustomerService.MockSearchGridResponseEntity);

            //Act
            var result = customerSupportService.GetGlobalSearchOptionListAdvanced(globalSearchOptionInputAdvancedEntity).Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].NumberOfLienCountActive);
            Assert.Equal(0, result[0].NumberOfLienCountRedeemed);
        }

        [Fact]
        public void GetLienHeaderInfoData_ByAssetId_ReturnsLienHeaderInfoEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetLienHeaderInfoByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockLienHeaderInfoEntity);

            //Act
            var result = customerSupportService.GetLienHeaderInfoByAssetId("").Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("0", result.AssetId);
        }

        [Fact]
        public void GetLienAssetInfoData_ByAssetId_ReturnsLienAssetInfoEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetLienAssetInfoByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockLienAssetInfoEntity);

            //Act
            var result = customerSupportService.GetLienAssetInfoByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("0", result[0].AssetId);
        }

        [Fact]
        public void GetLienRecentActivityData_ByAssetId_ReturnsLienRecentActivityEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetLienRecentActivityByAssetId(It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(MockCustomerService.MockLienRecentActivityEntity);

            //Act
            var result = customerSupportService.GetLienRecentActivityByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("", result[0].Action);
        }

        [Fact]
        public void GetEventTypeData_ByAssetId_ReturnsEventTypeEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetEventTypeByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockEventTypeEntity);

            //Act
            var result = customerSupportService.GetEventTypeByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].EventTypeId);
        }

        [Fact]
        public void GetFlagActionData_ByAssetId_ReturnsFlagActionEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetFlagActionByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockFlagActionEntity);

            //Act
            var result = customerSupportService.GetFlagActionByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].FlagActionId);
        }

        [Fact]
        public void GetOtherActionData_ByAssetId_ReturnsFlagActionEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetOtherActionByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockFlagActionEntity);

            //Act
            var result = customerSupportService.GetOtherActionByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].FlagActionId);
        }

        [Fact]
        public void GetEventTypeListData_ByDefault_ReturnsEventTypeEntity()
        {
            //Arrange
            mockEventRepository.Setup(repo => repo.GetEventTypeList()).ReturnsAsync(MockCustomerService.MockEventTypeEntity);

            //Act
            var result = customerSupportService.GetEventTypeList().Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].EventTypeId);
        }

        [Fact]
        public void GetEventActionListData_ByDefault_ReturnsEventActionEntity()
        {
            //Arrange
            mockEventRepository.Setup(repo => repo.GetEventActionList()).ReturnsAsync(MockCustomerService.MockEventActionList);

            //Act
            var result = customerSupportService.GetEventActionList().Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result[0].EventActionId);
            Assert.Equal("Test Event Action", result[0].EventActionName);
            Assert.False(result[0].IsActionflag);
        }


        [Fact]
        public void GetAddEventRelatedAssetData_ByAssetIdAndParcelId_ReturnsAddEventRelatedAssetEntity()
        {
            //Arrange
            mockEventRepository.Setup(repo => repo.GetRelatedAsset(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockAddEventRelatedAssetEntity);

            //Act
            var result = customerSupportService.GetRelatedAsset("", "").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("0", result[0].AssetId);
        }

        [Fact]
        public void GetContactData_ByAssetId_ReturnsContactEntity()
        {
            //Arrange
            mockEventRepository.Setup(repo => repo.GetContactByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockContactEntity);

            //Act
            var result = customerSupportService.GetContactByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].ContactId);
        }

        [Fact]
        public void GetEventActionCategoryListData_ByAssetId_ReturnsEventActionCategoryEntity()
        {
            //Arrange
            mockEventRepository.Setup(repo => repo.GetEventActionCategoryList()).ReturnsAsync(MockCustomerService.MockEventActionCategoryEntity);

            //Act
            var result = customerSupportService.GetEventActionCategoryList().Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].EventActionCategoryId);
        }

        [Fact]
        public void GetOwnerListData_ByAssetId_ReturnsOwnerEntity()
        {
            //Arrange
            mockOwnerRepository.Setup(repo => repo.GetOwnerListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockOwnerEntity);

            //Act
            var result = customerSupportService.GetOwnerListByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("TestOwner", result[0].OwnerName);
        }

        [Fact]
        public void GetContactListData_ByAssetId_ReturnsContactDetailsEntity()
        {
            //Arrange
            mockContactRepository.Setup(repo => repo.GetContactListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockContactDetailsEntity);

            //Act
            var result = customerSupportService.GetContactListByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].ContactId);
        }

        [Fact]
        public void GetContactTypeData_ByDefault_ReturnsContactTypeEntity()
        {
            //Arrange
            mockContactRepository.Setup(repo => repo.GetContactTypeList()).ReturnsAsync(MockCustomerService.MockContactTypeEntity);

            //Act
            var result = customerSupportService.GetContactType().Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].ContactTypeId);
        }

        [Fact]
        public void GetCityListData_ByStateId_ReturnsCityEntity()
        {
            //Arrange
            mockContactRepository.Setup(repo => repo.GetCityList(It.IsAny<int>())).ReturnsAsync(MockCustomerService.MockCityEntity);

            //Act
            var result = customerSupportService.GetCityList(0).Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].CityId);
        }

        [Fact]
        public void GetContact_ByContactId_ReturnsManageContact()
        {
            //Arrange
            mockContactRepository.Setup(repo => repo.GetContactByContactId(It.IsAny<int>())).ReturnsAsync(MockCustomerService.MockManageContact);

            //Act
            var result = customerSupportService.GetContactByContactId(0).Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("test1", result.AssetId[0]);
            Assert.Equal("test2", result.AssetId[1]);
        }

        [Fact]
        public void GetGlobalPopUpSearchResult_ByParcelIdAndAssetId_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            mockStateRepository.Setup(repo => repo.GetGlobalPopUpSearchResultByParcelIdAndAssetId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockSearchGridResponseEntity);

            //Act
            var result = customerSupportService.GetGlobalPopUpSearchResultByParcelIdAndAssetId("", "", "").Result;
            var response = result.ToList();
            //Assert
            Assert.NotNull(response);
            Assert.Equal(0, response.Select(i => i.NumberOfLienCountActive).FirstOrDefault());
            Assert.Equal(0, response.Select(i => i.NumberOfLienCountRedeemed).FirstOrDefault());
        }
        [Fact]
        public void GetLienCountAssetDetails_ByParcelIdAndAssetStatus_ReturnsRelatedAssetEntity()
        {
            //Arrange
            mockEventRepository.Setup(repo => repo.GetLienCountAssetDetails(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockAddEventRelatedAssetEntity);

            //Act
            var result = customerSupportService.GetLienCountAssetDetails("", "").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("0", result[0].AssetId);
        }
        [Fact]
        public void GetPropertyInfo_ByAssetId_ReturnsPropertyDetailsEntity()
        {
            //Arrange
            mockPropertyRepository.Setup(repo => repo.GetPropertyInfoByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockPropertyDetailsEntity);

            //Act
            var result = customerSupportService.GetPropertyInfoByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("New York", result[0].CityName);
        }
        [Fact]
        public void GetPropertyList_ByAssetId_ReturnsPropertyDetailsEntity()
        {
            //Arrange
            mockPropertyRepository.Setup(repo => repo.GetPropertyListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockPropertyDetailsEntity);

            //Act
            var result = customerSupportService.GetPropertyListByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("New York", result[0].CityName);
        }
        [Fact]
        public void GetDocumentList_ByAssetId_ReturnsDocumentEntity()
        {
            //Arrange
            mockDocumentRepository.Setup(repo => repo.GetDocumentListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockDocumentEntity);

            //Act
            var result = customerSupportService.GetDocumentListByAssetId("").Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result[0].AssetId);
        }
        [Fact]
        public void GetDocumentType_ReturnsDocumentTypeEntity()
        {
            //Arrange
            mockDocumentRepository.Setup(repo => repo.GetDocumentType()).ReturnsAsync(MockCustomerService.MockDocumentTypeEntity);

            //Act
            var result = customerSupportService.GetDocumentType().Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].DocumentTypeId);
        }
        [Fact]
        public void UpdateDocumentFlag_ByDocumentId_ReturnsInt()
        {
            //Arrange
            mockDocumentRepository.Setup(repo => repo.UpdateDocumentFlagByDocumentId(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(1);

            //Act
            var result = customerSupportService.UpdateDocumentFlagByDocumentId(0, "");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
        [Fact]
        public void DownloadFileAsync_ByDocumentFileId_ReturnsString()
        {
            //Arrange
            mockDocumentRepository.Setup(repo => repo.DownloadFileAsync(It.IsAny<int>())).ReturnsAsync("Test");

            //Act
            var result = customerSupportService.DownloadFileAsync(0);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result.Result);
        }
    }
}
