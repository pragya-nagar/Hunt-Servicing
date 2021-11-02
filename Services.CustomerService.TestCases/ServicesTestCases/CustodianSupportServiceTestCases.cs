using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.Services.Classes;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.TestCases.MockData;
using System.Linq;
using Xunit;

namespace Services.CustomerService.TestCases.ServicesTestCases
{
    public class CustodianSupportServiceTestCases
    {
        readonly Mock<IEventAssetRepository> mockEventAssetRepository;
        readonly Mock<ICertificateUploadFileRepository> mockCertificateUploadFileRepository;
        readonly ICustodianSupportService mockCustodianSupportService;

        public CustodianSupportServiceTestCases()
        {
            mockEventAssetRepository = new Mock<IEventAssetRepository>();
            mockCertificateUploadFileRepository = new Mock<ICertificateUploadFileRepository>();
            var mockLogger = new Mock<ILogger<ICustodianSupportService>>();
            mockCustodianSupportService = new CustodianSupportService(mockEventAssetRepository.Object, mockLogger.Object, mockCertificateUploadFileRepository.Object);
        }

        [Fact]
        public void GetRejectReasonList_ByDefault_ReturnsEventMasterRejectionReasonEntity()
        {
            //Arrange
            mockEventAssetRepository.Setup(repo => repo.GetRejectReasonList()).ReturnsAsync(MockCustodianSupportService.MockEventMasterRejectionReasonEntity);

            //Act
            var result = mockCustodianSupportService.GetRejectReasonList();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(0, result.Result.ToList()[0].EventMasterRejectionReasonId);
            Assert.Equal("TestName", result.Result.ToList()[0].EventMasterRejectionReasonName);
        }
        [Fact]
        public void GetPendingEvents_ByDefault_ReturnsPendingEventsEntity()
        {
            //Arrange
            mockEventAssetRepository.Setup(repo => repo.GetEventMaster(It.IsAny<int>())).ReturnsAsync(MockCustodianSupportService.MockPendingEventsEntity);

            //Act
            var result = mockCustodianSupportService.GetEventMaster(It.IsAny<int>());

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal("TestEventId", result.Result.ToList()[0].EventId);
            Assert.Equal("TS", result.Result.ToList()[0].StateCode);
        }
        [Fact]
        public void EventDetailsHeader_ByEventId_ReturnsEventDetailsHeaderEntity()
        {
            //Arrange
            mockEventAssetRepository.Setup(repo => repo.EventDetailsHeader(It.IsAny<string>())).ReturnsAsync(MockCustodianSupportService.MockEventDetailsHeaderEntity);

            //Act
            var result = mockCustodianSupportService.EventDetailsHeader("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Equal("TestEventId", result.Result.ToList()[0].EventId);
        }
        [Fact]
        public void EventDetails_ByEventId_ReturnsEventDetailsHeaderEntity()
        {
            //Arrange
            mockEventAssetRepository.Setup(repo => repo.EventDetails(It.IsAny<string>())).ReturnsAsync(MockCustodianSupportService.MockEventDetailsEntity);

            //Act
            var result = mockCustodianSupportService.EventDetails("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Equal("TestEventId", result.Result.ToList()[0].EventId);
        }
        [Fact]
        public void EventDetailsAssetList_ByEventId_ReturnsEventTypeAssetDetailsEntity()
        {
            //Arrange
            mockEventAssetRepository.Setup(repo => repo.EventDetailsAssetList(It.IsAny<string>())).ReturnsAsync(MockCustodianSupportService.MockEventTypeAssetDetailsEntity);

            //Act
            var result = mockCustodianSupportService.EventDetailsAssetList("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Equal("TestAssetID", result.Result.ToList()[0].AssetID);
        }


        [Fact]
        public void CertificateUploadFileHistory_ByDefault_ReturnsHistoryList()
        {
            //Arrange
            mockCertificateUploadFileRepository.Setup(repo => repo.GetUploadFileHistoryList(It.IsAny<int>())).ReturnsAsync(MockCustodianSupportService.MockCertificateUploadFileHistoryEntity);

            //Act
            var result = mockCustodianSupportService.GetUploadFileHistoryList(-1).Result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result[0].CertificateUploadFileId);
        }
    }
}
