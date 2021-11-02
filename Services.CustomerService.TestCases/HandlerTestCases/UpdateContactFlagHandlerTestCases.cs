using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class UpdateContactFlagHandlerTestCases
    {
        [Fact]
        public void HandleData_ByUpdateContactFlagCommandAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var updateContactFlagHandler = new UpdateContactFlagHandler(mockContactRepository.Object);

            var updateContactFlagCommand = new UpdateContactFlagCommand()
            {
                ContactId = 0
            };
            var cancellationToken = new CancellationToken();

            mockContactRepository.Setup(repo => repo.UpdateContactFlagByContactId(It.IsAny<int>())).ReturnsAsync(1);

            //Act
            var result = updateContactFlagHandler.Handle(updateContactFlagCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
