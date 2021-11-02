using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class RejectedEventsHandlerTestCases
    {
        [Fact]
        public void HandleData_ByCreateContactHandlerAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockEventAssetRepository = new Mock<IEventAssetRepository>();
            var rejectedEventsHandler = new RejectedEventsHandler(mockEventAssetRepository.Object);

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
            var cancellationToken = new CancellationToken();

            mockEventAssetRepository.Setup(repo => repo.RejectedEventsAction(It.IsAny<RejectedEventsActionCommand>())).ReturnsAsync(1);

            //Act
            var result = rejectedEventsHandler.Handle(rejectedEventsActionCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
