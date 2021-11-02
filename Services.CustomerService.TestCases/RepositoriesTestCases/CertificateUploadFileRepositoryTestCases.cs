using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Repositories;
using System;
using System.Threading.Tasks;
using Services.CustomerService.Command;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class CertificateUploadFileRepositoryTestCases
    {
        readonly CertificateUploadFileRepository certificateUploadFileRepository;

        public CertificateUploadFileRepositoryTestCases()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CertificateUploadFileRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            certificateUploadFileRepository = new CertificateUploadFileRepository(mockLogger.Object, mockIConfiguration.Object);
        }

        [Fact]
        public void CertificateUploadFileHistory_ByDefault_ReturnsHistoryList()
        {
            //Arrange
            certificateUploadFileRepository._conn = null;

            //Act
            var result = certificateUploadFileRepository.GetUploadFileHistoryList(-1);

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task CertificateUploadFileHistory_ByDefault_ReturnsHistoryListFailure()
        {
            //Arrange
            certificateUploadFileRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => certificateUploadFileRepository.GetUploadFileHistoryList(-1));
        }


        [Fact]
        public void RemoveUploadedFileFlag_ByFileId_ReturnsInt()
        {
            //Arrange
            certificateUploadFileRepository._conn = null;
            var removeUploadFileFlagCommand = new RemoveUploadFileFlagCommand()
            {
                CertificateUploadFileId = 1,
                UpdatedBy = Guid.NewGuid().ToString(),
                UpdatedByUserInitial = string.Empty
            };
            //Act
            var result = certificateUploadFileRepository.DeleteUploadedFileByFileId(removeUploadFileFlagCommand);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void RemoveUploadedFileFlag_ByFileId_ReturnsException()
        {
            //Arrange
            certificateUploadFileRepository._conn = null;
            var removeUploadFileFlagCommand = new RemoveUploadFileFlagCommand()
            {
                CertificateUploadFileId = 0,
                UpdatedBy = Guid.NewGuid().ToString(),
                UpdatedByUserInitial = string.Empty
            };

            //Act
            Assert.ThrowsAsync<ArgumentException>(() => certificateUploadFileRepository.DeleteUploadedFileByFileId(removeUploadFileFlagCommand));
        }
    }
}
