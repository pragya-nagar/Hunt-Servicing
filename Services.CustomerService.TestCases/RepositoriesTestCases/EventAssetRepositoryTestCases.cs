using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class EventAssetRepositoryTestCases
    {
        readonly Mock<IConfiguration> mockConfiguration;
        readonly Mock<ILogger<EventAssetRepository>> mockLogger;

        public EventAssetRepositoryTestCases()
        {
            mockConfiguration = new Mock<IConfiguration>();
            mockLogger = new Mock<ILogger < EventAssetRepository >> ();
        }

        [Fact]
        public void GetRejectReasonList_ByDefault_ReturnsEventMasterRejectionReasonEntity()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = null};

            //Act
            var result = eventAssetRepository.GetRejectReasonList();

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetRejectReasonList_ByDefault_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.GetRejectReasonList());
        }
        [Fact]
        public void GetPendingEvents_ByDefault_ReturnsPendingEventsEntity()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = null };

            //Act
            var result = eventAssetRepository.GetEventMaster(It.IsAny<int>());

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetPendingEvents_ByDefault_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.GetEventMaster(It.IsAny<int>()));
        }

        [Fact]
        public void RejectedEventsAction_ByRejectedEventsActionCommand_ReturnsInt()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = null };
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
            var result = eventAssetRepository.RejectedEventsAction(rejectedEventsActionCommand);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task RejectedEventsActionForApprovedList_ByRejectedEventsActionCommand_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };
            RejectedEventsActionCommand rejectedEventsActionCommand = new RejectedEventsActionCommand
            {
                ApprovedList = new[] { 0 },
                DeletedList = new int[] { },
                PendingList = new int[] { },
                RejectedList = new List<RejectedListProp>()
            };
            
            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.RejectedEventsAction(rejectedEventsActionCommand));
        }

        [Fact]
        public async System.Threading.Tasks.Task RejectedEventsActionForDeletedList_ByRejectedEventsActionCommand_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };
            RejectedEventsActionCommand rejectedEventsActionCommand = new RejectedEventsActionCommand
            {
                ApprovedList = new int[] { },
                DeletedList = new[] { 0 },
                PendingList = new int[] { },
                RejectedList = new List<RejectedListProp>()
            };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.RejectedEventsAction(rejectedEventsActionCommand));
        }

        [Fact]
        public async System.Threading.Tasks.Task RejectedEventsActionForPendingList_ByRejectedEventsActionCommand_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };
            RejectedEventsActionCommand rejectedEventsActionCommand = new RejectedEventsActionCommand
            {
                ApprovedList = new int[] { },
                DeletedList = new int[] { },
                PendingList = new[] { 0 },
                RejectedList = new List<RejectedListProp>()
            };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.RejectedEventsAction(rejectedEventsActionCommand));
        }

        [Fact]
        public async System.Threading.Tasks.Task RejectedEventsActionForRejectedList_ByRejectedEventsActionCommand_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };
            RejectedEventsActionCommand rejectedEventsActionCommand = new RejectedEventsActionCommand
            {
                ApprovedList = new int[] { },
                DeletedList = new int[] { },
                PendingList = new int[] { },
                RejectedList = new List<RejectedListProp>
                {
                    new RejectedListProp
                    {
                        EventMasterId = 0,
                        RejectedReason = 0
                    }
                }
            };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.RejectedEventsAction(rejectedEventsActionCommand));
        }

        [Fact]
        public void EventDetailsHeader_ByEventId_ReturnsEventDetailsHeaderEntity()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = null };
            

            //Act
            var result = eventAssetRepository.EventDetailsHeader("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task EventDetailsHeader_ByEventId_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.EventDetailsHeader("TestEventId"));
        }

        [Fact]
        public void EventDetails_ByEventId_ReturnsEventDetailsEntity()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = null };


            //Act
            var result = eventAssetRepository.EventDetails("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task EventDetails_ByEventId_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.EventDetails("TestEventId"));
        }

        [Fact]
        public void EventDetailsAssetList_ByEventId_ReturnsEventTypeAssetDetailsEntity()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = null };


            //Act
            var result = eventAssetRepository.EventDetailsAssetList("TestEventId");

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task EventDetailsAssetList_ByEventId_ReturnsArgumentException()
        {
            //Arrange
            var eventAssetRepository = new EventAssetRepository(mockLogger.Object, mockConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventAssetRepository.EventDetailsAssetList("TestEventId"));
        }
    }
}
