using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class RemoveEventTypeFlagHandlerTestCases
    {
        [Fact]
        public void HandleData_ByRemoveEventTypeFlagCommandAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockEventRepository = new Mock<IEventRepository>();
            var createEventHandler = new RemoveEventTypeFlagHandler(mockEventRepository.Object);

            var removeEventTypeFlagCommand = new RemoveEventTypeFlagCommand()
            {
                EventTypeId = 0
            };
            var cancellationToken = new CancellationToken();

            mockEventRepository.Setup(repo => repo.RemoveEventTypeFlagByEventId(It.IsAny<int>())).ReturnsAsync(1);

            //Act
            var result = createEventHandler.Handle(removeEventTypeFlagCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
