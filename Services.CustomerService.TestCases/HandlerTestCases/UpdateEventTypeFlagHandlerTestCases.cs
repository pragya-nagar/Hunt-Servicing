using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class UpdateEventTypeFlagHandlerTestCases
    {
        [Fact]
        public void HandleData_ByUpdateEventTypeFlagCommandAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var createEventHandler = new UpdateEventTypeFlagHandler(mockEventRepository.Object);

            var updateEventTypeFlagCommand = new UpdateEventTypeFlagCommand()
            {
                EventTypeId = 0
            };
            var cancellationToken = new CancellationToken();

            mockEventRepository.Setup(repo => repo.UpdateEventTypeFlagByEventId(It.IsAny<int>())).ReturnsAsync(1);

            //Act
            var result = createEventHandler.Handle(updateEventTypeFlagCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
