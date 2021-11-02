using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class CreateEventHandlerTestCases
    {
        [Fact]
        public void HandleData_ByCreateEventCommandAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var createEventHandler = new CreateEventHandler(mockEventRepository.Object);

            var createEventCommand = new CreateEventCommand()
            {
                ActionCategory = 0,
                ActionId = 0,
                AssetId = new List<string>(new[] { "test1", "test2" }),
                ContactId = 0,
                CreatedBy = Guid.NewGuid().ToString(),
                EventDate = DateTime.Now,
                EventTypeId = 0,
                HighLightFlag = false,
                Note = ""
            };
            var cancellationToken = new CancellationToken();

            mockEventRepository.Setup(repo => repo.CreateEventId(It.IsAny<CreateEventCommand>())).ReturnsAsync(1);
            
            //Act
            var result = createEventHandler.Handle(createEventCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
