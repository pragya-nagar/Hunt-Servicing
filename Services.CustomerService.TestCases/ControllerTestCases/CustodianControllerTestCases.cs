using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.CustomerService.Controllers;
using Services.CustomerService.Command;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.TestCases.MockData;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.ControllerTestCases
{
    public class CustodianControllerTestCases
    {
        readonly Mock<ICustodianSupportService> mockCustodianSupportService;
        readonly Mock<IMediator> mockMediator;
        readonly CustodianController mockCustodianController;

        public CustodianControllerTestCases()
        {
            mockCustodianSupportService = new Mock<ICustodianSupportService>();
            mockMediator = new Mock<IMediator>();
            mockCustodianController = new CustodianController(mockCustodianSupportService.Object, mockMediator.Object);
        }
        [Fact]
        public void GetRejectReasonList_ByDefault_ReturnsEventMasterRejectionReasonEntity()
        {
            //Arrange
            mockCustodianSupportService.Setup(repo => repo.GetRejectReasonList()).ReturnsAsync(MockCustodianSupportService.MockEventMasterRejectionReasonEntity);
            
            //Act
            var result = mockCustodianController.GetRejectReasonList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void GetPendingEvents_ByDefault_ReturnsPendingEventsEntity()
        {
            //Arrange
            mockCustodianSupportService.Setup(repo => repo.GetEventMaster(It.IsAny<int>())).ReturnsAsync(MockCustodianSupportService.MockPendingEventsEntity);

            //Act
            var result = mockCustodianController.GetEventMaster(It.IsAny<int>());

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        
        [Fact]
        public void RejectedEventsAction_ByRejectedEventsActionCommand_ReturnsInt()
        {
            //Arrange
            mockMediator.Setup(repo => repo.Send(It.IsAny<RejectedEventsActionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

            RejectedEventsActionCommand rejectedEventsActionCommand = new RejectedEventsActionCommand
            {
                ApprovedList = new[] { 0 },
                DeletedList = new[] { 0 },
                PendingList = new[] { 0 },
                RejectedList = new List<RejectedListProp>
                {
                    new RejectedListProp
                    {
                        EventMasterId = 0,
                        RejectedReason = 0
                    }
                }
            };

            //Act
            var result = mockCustodianController.RejectedEventsAction(rejectedEventsActionCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
        [Fact]
        public void RejectedEventsAction_ByRejectedEventsActionCommand_ReturnsZero()
        {
            //Arrange
            mockMediator.Setup(repo => repo.Send(It.IsAny<RejectedEventsActionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

            //Act
            var result = mockCustodianController.RejectedEventsAction(null);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void EventDetailsHeader_ByEventId_ReturnsEventDetailsHeaderEntity()
        {
            //Arrange
            mockCustodianSupportService.Setup(repo=> repo.EventDetailsHeader(It.IsAny<string>())).ReturnsAsync(MockCustodianSupportService.MockEventDetailsHeaderEntity);

            //Act
            var result = mockCustodianController.EventDetailsHeader("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void EventDetails_ByEventId_ReturnsEventDetailsEntity()
        {
            //Arrange
            mockCustodianSupportService.Setup(repo => repo.EventDetails(It.IsAny<string>())).ReturnsAsync(MockCustodianSupportService.MockEventDetailsEntity);

            //Act
            var result = mockCustodianController.EventDetails("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void EventDetailsAssetList_ByEventId_ReturnsEventTypeAssetDetailsEntity()
        {
            //Arrange
            mockCustodianSupportService.Setup(repo => repo.EventDetailsAssetList(It.IsAny<string>())).ReturnsAsync(MockCustodianSupportService.MockEventTypeAssetDetailsEntity);

            //Act
            var result = mockCustodianController.EventDetailsAssetList("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.
                Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }

        [Fact]
        public void EventCertificateUploadFileHistory_ByDefault_ReturnsHistoryList()
        {
            //Arrange
            mockCustodianSupportService.Setup(repo => repo.GetUploadFileHistoryList(It.IsAny<int>())).ReturnsAsync(MockCustodianSupportService.MockCertificateUploadFileHistoryEntity);

            //Act
            var result = mockCustodianController.GetUploadFileHistoryList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result.Result).StatusCode);
            Assert.NotNull((OkObjectResult)result.Result);
        }

        [Fact]
        public void RemoveEventFlag_ByRemoveEventTypeFlagCommand_ReturnsEventId()
        {
            var removeEventTypeFlagCommand = new RemoveUploadFileFlagCommand
            {
                CertificateUploadFileId = -1
            };
            mockMediator.Setup(m => m.Send(It.IsAny<RemoveUploadFileFlagCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

            //Act
            var result = mockCustodianController.DeleteUploadedFile(removeEventTypeFlagCommand);

            //Assert
            Assert.Equal(200, ((OkObjectResult)result.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)result.Result));
        }
    }
}

