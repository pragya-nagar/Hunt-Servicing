using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Controllers;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.TestCases.MockData;
using Services.CustomerService.ViewModel;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.ControllerTestCases
{
    public class AssetServiceControllerTestCases
    {
        [Fact]
        public void StateListData_ByDefault_ReturnsStateList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            mockCustomerService.Setup(repo => repo.GetListAsync()).ReturnsAsync(MockCustomerService.MockStateList);
            //Act
            var result = AssetServiceController.GetStateList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void AssetStatusListData_ByDefault_ReturnsAssetStatusList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetAssetStatusListAsync()).ReturnsAsync(MockCustomerService.MockAssetStatusList);
            //Act
            var result = AssetServiceController.GetAssetStatusList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void EventTypeListData_ByDefault_ReturnsEventTypeList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetEventTypeList()).ReturnsAsync(MockCustomerService.MockEventTypeEntity);
            //Act
            var result = AssetServiceController.GetEventTypeList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void EventActionListData_ByDefault_ReturnsEventActionList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetEventActionList()).ReturnsAsync(MockCustomerService.MockEventActionList);
            //Act
            var result = AssetServiceController.GetEventActionList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GlobalSearchOptionListData_ByAssetIDAndFilterType_ReturnsGetGlobalSearchOptionList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetGlobalSearchOptionList(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockGlobalSearchOptionEntity);
            //Act
            var result = AssetServiceController.GetGlobalSearchOptionList("", "");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        
        [Fact]
        public void GetGlobalPopUpSearchOptionData_ByParcelId_ReturnsGetGlobalPopUpSearchOptionList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            mockCustomerService.Setup(repo => repo.GetGlobalPopUpSearchOptionListByParcelId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockSearchGridResponseEntity);

            //Act
            var result = AssetServiceController.GetGlobalPopUpSearchOptionListByParcelId("", "","");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetGlobalPopUpSearchOptionData_ByParcelIdAndAssetId_ReturnsGetGlobalPopUpSearchOptionList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            mockCustomerService.Setup(repo => repo.GetGlobalPopUpSearchResultByParcelIdAndAssetId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockSearchGridResponseEntity);

            //Act
            var result = AssetServiceController.GetGlobalPopUpSearchResultByParcelIdAndAssetId("","", "");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetGlobalSearchOptionData_ByParcelIdAndSearchValue_ReturnsSearchGridResponseEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            var globalSearchOptionInputAdvancedEntity = new GlobalSearchOptionInputAdvancedEntity();
            mockCustomerService.Setup(repo => repo.GetGlobalSearchOptionListAdvanced(It.IsAny<GlobalSearchOptionInputAdvancedEntity>())).ReturnsAsync(MockCustomerService.MockSearchGridResponseEntity);

            //Act
            var result = AssetServiceController.GetGlobalSearchOptionListAdvanced(globalSearchOptionInputAdvancedEntity);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetLienHeaderInfoData_ByAssetId_ReturnsLienHeaderInfoEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            mockCustomerService.Setup(repo => repo.GetLienHeaderInfoByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockLienHeaderInfoEntity);

            //Act
            var result = AssetServiceController.GetLienHeaderInfoByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetLienAssetInfoData_ByAssetId_ReturnsLienAssetInfoEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetLienAssetInfoByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockLienAssetInfoEntity);

            //Act
            var result = AssetServiceController.GetLienAssetInfoByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetLienRecentActivityInfoData_ByAssetId_ReturnsLienRecentActivityEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetLienRecentActivityByAssetId(It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(MockCustomerService.MockLienRecentActivityEntity);

            //Act
            var result = AssetServiceController.GetLienRecentActivityInfoByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetEventTypeData_ByAssetId_ReturnsEventTypeEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetEventTypeByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockEventTypeEntity);

            //Act
            var result = AssetServiceController.GetEventTypeByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetFlagActionByData_ByAssetId_ReturnsFlagActionEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetFlagActionByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockFlagActionEntity);

            //Act
            var result = AssetServiceController.GetFlagActionByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetOtherActionByData_ByAssetId_ReturnsFlagActionEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetOtherActionByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockFlagActionEntity);

            //Act
            var result = AssetServiceController.GetOtherActionByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetAddEventRelatedAssetData_ByAssetIdAndParcelId_ReturnsAddEventRelatedAssetEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetRelatedAsset(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockAddEventRelatedAssetEntity);

            //Act
            var result = AssetServiceController.GetRelatedAsset("", "");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetContactData_ByAssetId_ReturnsContactEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetContactByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockContactEntity);

            //Act
            var result = AssetServiceController.GetContactByAsset("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetEventActionCategoryListData_ReturnsEventActionCategoryEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetEventActionCategoryList()).ReturnsAsync(MockCustomerService.MockEventActionCategoryEntity);

            //Act
            var result = AssetServiceController.GetEventActionCategoryList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void PostEvent_ByCreateEventCommand_ReturnsEventId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            var listInt = new List<string> {"1"};
            var createEventCommand = new CreateEventCommand() {
                ActionCategory = -125,
                AssetId = listInt
            };
            mediator
                .Setup(m => m.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            //Act
            var result = AssetServiceController.CreateEvent(createEventCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void PostEvent_ByCreateEventCommand_ReturnsEventIdFailure()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            var createEventCommand = new CreateEventCommand()
            {
                ActionCategory = -125
            };

            //Act
            var result = AssetServiceController.CreateEvent(createEventCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void RemoveEventFlag_ByRemoveEventTypeFlagCommand_ReturnsEventId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            
            var removeEventTypeFlagCommand = new RemoveEventTypeFlagCommand()
            {
               EventTypeId = -1
            };
            mediator
                .Setup(m => m.Send(It.IsAny<RemoveEventTypeFlagCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            //Act
            var result = AssetServiceController.PutRemoveEventFlag(removeEventTypeFlagCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void RemoveEventFlagFail_ByRemoveEventTypeFlagCommand_ReturnsEventId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            
            var removeEventTypeFlagCommand = new RemoveEventTypeFlagCommand()
            {
                EventTypeId = -1
            };
            mediator
                .Setup(m => m.Send(It.IsAny<RemoveEventTypeFlagCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);

            //Act
            var result = AssetServiceController.PutRemoveEventFlag(removeEventTypeFlagCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void UpdateEventFlag_ByUpdateEventTypeFlagCommand_ReturnsEventId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
      
            var updateEventTypeFlagCommand = new UpdateEventTypeFlagCommand()
            {
                EventTypeId = -1
            };
            mediator
                .Setup(m => m.Send(It.IsAny<UpdateEventTypeFlagCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            //Act
            var result = AssetServiceController.PutUpdateEventFlag(updateEventTypeFlagCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void UpdateEventFlagFail_ByRemoveEventTypeFlagCommand_ReturnsEventId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
           
            var updateEventTypeFlagCommand = new UpdateEventTypeFlagCommand()
            {
                EventTypeId = -1
            };
            mediator
                .Setup(m => m.Send(It.IsAny<UpdateEventTypeFlagCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);

            //Act
            var result = AssetServiceController.PutUpdateEventFlag(updateEventTypeFlagCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void GetGetOwnerList_ByAssetId_ReturnsOwnerEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetOwnerListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockOwnerEntity);

            //Act
            var result = AssetServiceController.GetOwnerListByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void GetContactList_ByAssetId_ReturnsContactDetailsEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetContactListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockContactDetailsEntity);

            //Act
            var result = AssetServiceController.GetContactListByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void GetContactType_ByDefault_ReturnsContactTypeEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetContactType()).ReturnsAsync(MockCustomerService.MockContactTypeEntity);

            //Act
            var result = AssetServiceController.GetContactType();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void DeleteContactByFlag_ByUpdateContactFlagCommand_ReturnsContactId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            var updateContactFlagCommand = new UpdateContactFlagCommand()
            {
                ContactId = 0
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<UpdateContactFlagCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(1);
            //Act
            var result = AssetServiceController.DeleteContactByFlag(updateContactFlagCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void DeleteContactByFlag_ByUpdateContactFlagCommand_ReturnsContactIdFailure()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            var updateContactFlagCommand = new UpdateContactFlagCommand()
            {
                ContactId = 0
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<UpdateContactFlagCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(0);
            //Act
            var result = AssetServiceController.DeleteContactByFlag(updateContactFlagCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void CreateContact_ByCreateContactCommand_ReturnsContactId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            var listStr = new List<string> {"1"};
            var createContactCommand = new CreateContactCommand()
            {
                AssetId = listStr
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<CreateContactCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(1);
            //Act
            var result = AssetServiceController.CreateContact(createContactCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void CreateContact_ByCreateContactCommand_ReturnsContactIdFailure()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            var createContactCommand = new CreateContactCommand()
            {
                FirstName = "Test"
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<CreateContactCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(0);
            //Act
            var result = AssetServiceController.CreateContact(createContactCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void GetCityListByStateId_ByStateId_ReturnsCityEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetCityList(It.IsAny<int>())).ReturnsAsync(MockCustomerService.MockCityEntity);

            //Act
            var result = AssetServiceController.GetCityListByStateId(0);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void GetContact_ByContactId_ReturnsManageContact()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetContactByContactId(It.IsAny<int>())).ReturnsAsync(MockCustomerService.MockManageContact);

            //Act
            var result = AssetServiceController.GetContactByContactId(0);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void UpdateContact_ByUpdateContactCommand_ReturnsContactId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            var listStr = new List<string> {"Test1"};
            var updateContactCommand = new UpdateContactCommand()
            {
                ContactId = 125,
                AssetId = listStr
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<UpdateContactCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(1);
            //Act
            var result = AssetServiceController.UpdateContact(updateContactCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void UpdateContact_ByUpdateContactCommand_ReturnsContactIdFailed()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            var listStr = new List<string> {"Test1"};
            var updateContactCommand = new UpdateContactCommand()
            {
                ContactId = -125,
                AssetId = listStr
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<UpdateContactCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(0);
            //Act
            var result = AssetServiceController.UpdateContact(updateContactCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetLienCountAssetDetails_ByParcelIdAndAssetStatus_ReturnsRelatedAssetEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetLienCountAssetDetails(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockAddEventRelatedAssetEntity);

            //Act
            var result = AssetServiceController.GetLienCountAssetDetails("", "");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetPropertyInfo_ByAssetId_ReturnsRelatedAssetEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetPropertyInfoByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockPropertyDetailsEntity);

            //Act
            var result = AssetServiceController.GetPropertyInfoByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetDocumentList_ByAssetId_ReturnsDocumentEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetDocumentListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockDocumentEntity);

            //Act
            var result = AssetServiceController.GetDocumentListByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetDocumentType_ByAssetId_ReturnsDocumentEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetDocumentType()).ReturnsAsync(MockCustomerService.MockDocumentTypeEntity);

            //Act
            var result = AssetServiceController.GetDocumentType();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetPropertyList_ByAssetId_ReturnsRelatedAssetEntity()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.GetPropertyListByAssetId(It.IsAny<string>())).ReturnsAsync(MockCustomerService.MockPropertyDetailsEntity);

            //Act
            var result = AssetServiceController.GetPropertyListByAssetId("");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void CreateDocument_ByCreateDocumentCommand_ReturnsDocumentIdSuccess()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            var testList = new List<string>() { "test1", "Test2" };
            var createDocumentCommand = new CreateDocumentCommand()
            {
               CreatedBy = Guid.NewGuid().ToString(),
               AssetId= testList
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<CreateDocumentCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(0);
            //Act
            var result = AssetServiceController.CreateDocument(createDocumentCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void RemoveDocument_ByDocumentId_ReturnsDocumentId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.UpdateDocumentFlagByDocumentId(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(1);

            //Act
            var result = AssetServiceController.RemoveDocumentByDocumentId(0,"");

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void CreateDocument_ByCreateDocumentCommand_ReturnsDocumentIdFailure()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);
            var createDocumentCommand = new CreateDocumentCommand()
            {
                CreatedBy = Guid.NewGuid().ToString(),
            };

            mediator
                 .Setup(m => m.Send(It.IsAny<CreateDocumentCommand>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(0);
            //Act
            var result = AssetServiceController.CreateDocument(createDocumentCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void DownloadFileAsync_ByDocumentFileId_ReturnsString()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerSupportService>();
            var mediator = new Mock<IMediator>();
            var AssetServiceController = new AssetServiceController(mockCustomerService.Object, mediator.Object);

            mockCustomerService.Setup(repo => repo.DownloadFileAsync(It.IsAny<int>())).ReturnsAsync("Test");

            //Act
            var result = AssetServiceController.DownloadFileAsync(0);

            //Assert
            Assert.NotNull(result);
        }
    }
}
