using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Common.Entity;
using Services.Common.S3Management.Interfaces;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories;
using Services.CustomerService.TestCases.MockData;
using System;
using System.Collections.Generic;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class DocumentRepositoryTestCases
    {

        private readonly Mock<ILogger<DocumentRepository>> mockLogger;
        private readonly Mock<IConfiguration> mockIConfiguration;
        private readonly Mock<IFileManagement> mockIFileManagement;

        public DocumentRepositoryTestCases()
        {
            mockLogger = new Mock<ILogger<DocumentRepository>>();
            mockIConfiguration = new Mock<IConfiguration>();
            mockIFileManagement = new Mock<IFileManagement>();
        }

        [Fact]
        public void GetDocumentList_ByAssetId_ReturnsDocumentListEntity()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = null };

            //Act
            var result = documentRepository.GetDocumentListByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }
        [Fact]
        public void GetDocumentType_ByAssetId_ReturnsDocumentTypeListEntity()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = null };

            //Act
            var result = documentRepository.GetDocumentType();

            //Assert
            Assert.Null(result.Result);
        }
        [Fact]
        public void UpdateDocument_ByDocumentId_ReturnsInt()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = null };

            //Act
            var result = documentRepository.UpdateDocumentFlagByDocumentId(1, "");

            //Assert
            Assert.Equal(1, result.Result);
        }
        [Fact]
        public void CreateDocument_ByCreateCommand_ReturnsInt()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = null };
            var createDocumentCommand = new CreateDocumentCommand()
            {
                AssetId = new List<string>(new[] { "test1", "test2" }),
                CreatedBy = Guid.NewGuid().ToString(),
                DocumentReceiveDate = "",
                DocumentTitle = "Test",
                DocumentTypeId = 0,
                DocumentUploadDate = "",
                FileDataList = new List<FileDetailsEntity>(),
                Note = ""
            };

            mockIFileManagement
                 .Setup(m => m.UploadDocumentToS3(It.IsAny<List<FileDetailsEntity>>()))
                 .ReturnsAsync(MockRepoData.MockDictionary);
            documentRepository._IFileManagement = mockIFileManagement.Object;

            //Act
            var result = documentRepository.CreateDocument(createDocumentCommand);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void DownloadFileAsync_ByDocumentFileId_ReturnsEmptyString()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = null };

            //Act
            var result = documentRepository.DownloadFileAsync(0);

            //Assert
            Assert.Equal(String.Empty, result.Result);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetDocumentList_ByAssetId_ReturnsArgumentException()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => documentRepository.GetDocumentListByAssetId(""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetDocumentType_ByAssetId_ReturnsArgumentException()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => documentRepository.GetDocumentType());
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateDocument_ByDocumentId_ReturnsArgumentException()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => documentRepository.UpdateDocumentFlagByDocumentId(1, ""));
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateDocument_ByCreateCommand_ReturnsArgumentException()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };
            var createDocumentCommand = new CreateDocumentCommand()
            {
                AssetId = new List<string>(new[] { "test1", "test2" }),
                CreatedBy = Guid.NewGuid().ToString(),
                DocumentReceiveDate = "",
                DocumentTitle = "Test",
                DocumentTypeId = 0,
                DocumentUploadDate = "",
                FileDataList = new List<FileDetailsEntity>(),
                Note = ""
            };

            mockIFileManagement
                 .Setup(m => m.UploadDocumentToS3(It.IsAny<List<FileDetailsEntity>>()))
                 .ReturnsAsync(MockRepoData.MockDictionary);
            documentRepository._IFileManagement = mockIFileManagement.Object;

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => documentRepository.CreateDocument(createDocumentCommand));
        }



        [Fact]
        public async System.Threading.Tasks.Task DownloadFileAsync_ByDocumentFileId_ReturnsArgumentException()
        {
            //Arrange
            var documentRepository = new DocumentRepository(mockIFileManagement.Object, mockLogger.Object, mockIConfiguration.Object) { _conn = "Test" };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => documentRepository.DownloadFileAsync(0));
        }
    }

}