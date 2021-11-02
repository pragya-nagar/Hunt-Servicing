using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Common.Entity;
using Services.Common.S3Management;
using Services.Common.S3Management.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Services.Common.TestCases.S3Management
{
    public class FileManagementTestCases
    {
        readonly Mock<IAmazonS3> mockAmazonS3;
        readonly IFileManagement fileManagement;

        public FileManagementTestCases()
        {
            mockAmazonS3 = new Mock<IAmazonS3>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockLogger = new Mock<ILogger<FileManagement>>();
            mockConfiguration.Setup(repo => repo["BucketName"]).Returns("Test");
            fileManagement = new FileManagement(mockAmazonS3.Object, mockConfiguration.Object, mockLogger.Object);
        }

        [Fact]
        public void UploadDocumentToS3_ByFileDetailsEntities_ReturnsDictionaryOfStringAndString()
        {
            //Arrange
            var mockFileEntry = new FileDetailsEntity()
            {
                FileData = "TestData",
                FileName = "TestName"
            };
            var mockList = new List<FileDetailsEntity>() { mockFileEntry };
            var putObjectResponse = new PutObjectResponse();
            var listObjectResponse = new ListObjectsResponse();
            mockAmazonS3.Setup(repo => repo.PutObjectAsync(It.IsAny<PutObjectRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(putObjectResponse));
            mockAmazonS3.Setup(repo => repo.ListObjectsAsync(It.IsAny<ListObjectsRequest>(), It.IsAny<CancellationToken>()))
              .Returns(Task.FromResult(listObjectResponse));
            //Act
            var result = fileManagement.UploadDocumentToS3(mockList);

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal("TestName", result.Result.ToList()[0].Value);
        }

        [Fact]
        public async Task UploadDocumentToS3_ByFileDetailsEntities_ReturnsNullReferenceException()
        {
            //Arrange
            var mockList = new List<FileDetailsEntity>() { null };
            var putObjectResponse = new PutObjectResponse();

            mockAmazonS3.Setup(repo => repo.PutObjectAsync(It.IsAny<PutObjectRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(putObjectResponse));

            //Act, Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => fileManagement.UploadDocumentToS3(mockList));

        }

        [Fact]
        public void DeleteAsync_ByFileName_ReturnsDeleteObjectResponse()
        {
            //Arrange
            var mockFileName = "TestName";
            var deleteObjectResponse = new DeleteObjectResponse() { DeleteMarker = "TestDeletedMark" };

            mockAmazonS3.Setup(repo => repo.DeleteObjectAsync(It.IsAny<DeleteObjectRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(deleteObjectResponse));

            //Act
            var result = (Task<DeleteObjectResponse>)fileManagement.DeleteAsync(mockFileName);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("TestDeletedMark", result.Result.DeleteMarker);
        }

        [Fact]
        public async Task DeleteAsync_ByFileName_ReturnsNullReferenceException()
        {
            //Arrange
            mockAmazonS3.Setup(repo => repo.DeleteObjectAsync(It.IsAny<DeleteObjectRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromException<DeleteObjectResponse>(new ArgumentException("Update failed ...")));

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => fileManagement.DeleteAsync("TestFileName"));
        }

        [Fact]
        public void GetFileData_ByKey_ReturnsBase64EncodedString()
        {
            //Arrange
            var data = "test response content";
            var encodedDataBytes = Encoding.UTF8.GetBytes(data);
            var responseStream = new MemoryStream();
            responseStream.Write(encodedDataBytes, 0, encodedDataBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            var getObjectResponse = new GetObjectResponse() { ResponseStream = responseStream };
            mockAmazonS3.Setup(repo => repo.GetObjectAsync(It.IsAny<GetObjectRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(getObjectResponse));

            var expectedData = Convert.ToBase64String(responseStream.ToArray());

            //Act
            var result = fileManagement.GetFileData("Test Key");

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(expectedData, result.Result);
        }

        [Fact]
        public async Task GetFileData_ByKey_ReturnsNullReferenceException()
        {
            //Arrange
            var getObjectResponse = new GetObjectResponse();
            mockAmazonS3.Setup(repo => repo.GetObjectAsync(It.IsAny<GetObjectRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(getObjectResponse));

            //Act, Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => fileManagement.GetFileData("Test Key"));
        }
    }
}
