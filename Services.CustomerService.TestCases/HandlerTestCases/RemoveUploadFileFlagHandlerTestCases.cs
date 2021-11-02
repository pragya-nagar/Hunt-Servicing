using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class RemoveUploadFileFlagHandlerTestCases
    {
        [Fact]
        public void HandleData_ByRemoveUploadFileFlagCommandAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockUploadFileRepository = new Mock<ICertificateUploadFileRepository>();
            var removeUploadFileFlagHandler = new RemoveUploadFileFlagHandler(mockUploadFileRepository.Object);

            var removeUploadFileFlagCommand = new RemoveUploadFileFlagCommand()
            {
                CertificateUploadFileId = 0
            };

            mockUploadFileRepository.Setup(repo => repo.DeleteUploadedFileByFileId(It.IsAny<RemoveUploadFileFlagCommand>())).ReturnsAsync(1);

            //Act
            var result = removeUploadFileFlagHandler.Handle(removeUploadFileFlagCommand, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
