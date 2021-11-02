using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class EventRepositoryTestCases
    {
        readonly EventRepository eventRepository;

        public EventRepositoryTestCases()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<EventRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            eventRepository = new EventRepository(mockLogger.Object, mockIConfiguration.Object);
        }

        [Fact]
        public void UpdateEventTypeFlag_ByEventId_ReturnsInt()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            var result = eventRepository.UpdateEventTypeFlagByEventId(10);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void RemoveEventTypeFlag_ByEventId_ReturnsInt()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            var result = eventRepository.RemoveEventTypeFlagByEventId(10);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void RemoveEventTypeFlag_ByEventId_ReturnsException()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            Assert.ThrowsAsync<ArgumentException>(() => eventRepository.RemoveEventTypeFlagByEventId(0));
        }


        [Fact]
        public void GetEventTypeList_ByDefault_ReturnsEventTypeEntity()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            var result = eventRepository.GetEventTypeList();

            //Assert
            Assert.Null(result.Result);
        }


        [Fact]
        public void GetEventActionList_ByDefault_ReturnsEventActionEntity()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            var result = eventRepository.GetEventActionList();

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetRelatedAsset_ByAssetIdAndParcelId_ReturnsRelatedAssetEntity()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            var result = eventRepository.GetRelatedAsset("", "");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetContact_ByAssetId_ReturnsContactEntity()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            var result = eventRepository.GetContactByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void CreateEventId_ByAssetId_ReturnsInt()
        {
            //Arrange
            eventRepository._conn = null;

            var createEventCommand = new CreateEventCommand()
            {
                ActionCategory = 10,
                ActionId = 10,
                AssetId = new List<string> { "Test" },
                ContactId = 10,
                EventTypeId = 10,
                EventDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString()
            };

            //Act
            var result = eventRepository.CreateEventId(createEventCommand);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void GetEventActionCategoryList_ByDefault_ReturnsEventActionCategoryEntity()
        {
            //Arrange
            eventRepository._conn = null;

            //Act
            var result = eventRepository.GetEventActionCategoryList();

            //Assert
            Assert.Null(result.Result);
        }
        [Fact]
        public async Task UpdateEventTypeFlag_ByEventIdLessThenZeroForElse_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = null;
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.UpdateEventTypeFlagByEventId(-1));
        }
        [Fact]
        public async Task RemoveEventTypeFlag_ByEventIdLessThenZeroForElse_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = null;
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.RemoveEventTypeFlagByEventId(-1));
        }
        [Fact]
        public async Task UpdateEventTypeFlag_ByEventId_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.UpdateEventTypeFlagByEventId(10));
        }

        [Fact]
        public async Task RemoveEventTypeFlag_ByEventId_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.RemoveEventTypeFlagByEventId(10));
        }

        [Fact]
        public async Task GetEventTypeList_ByDefault_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.GetEventTypeList());
        }

        [Fact]
        public async Task GetEventActionList_ByDefault_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.GetEventActionList());
        }

        [Fact]
        public async Task GetRelatedAsset_ByAssetIdAndParcelId_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.GetRelatedAsset("", ""));
        }

        [Fact]
        public async Task GetContact_ByAssetId_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.GetContactByAssetId(""));
        }

        [Fact]
        public async Task CreateEventId_ByAssetId_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            var createEventCommand = new CreateEventCommand()
            {
                ActionCategory = 10,
                ActionId = 10,
                AssetId = new List<string> { "Test" },
                ContactId = 10,
                EventTypeId = 10,
                EventDate = DateTime.Now,
                CreatedBy = Guid.NewGuid().ToString()
            };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.CreateEventId(createEventCommand));
        }

        [Fact]
        public async Task GetEventActionCategoryList_ByDefault_ReturnsArgumentException()
        {
            //Arrange
            eventRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => eventRepository.GetEventActionCategoryList());
        }

    }
}
