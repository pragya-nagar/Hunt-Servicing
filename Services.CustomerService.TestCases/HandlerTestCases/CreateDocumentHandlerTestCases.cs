using System;
using Moq;
using Services.Common.Entity;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class CreateDocumentHandlerTestCases
    {
        [Fact]
        public void HandleData_ByCreateContactHandlerAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockDocumentRepository = new Mock<IDocumentRepository>();
            var updateContactFlagHandler = new CreateDocumentHandler(mockDocumentRepository.Object);

            var createDocumentCommand = new CreateDocumentCommand()
            {
                AssetId = new List<string>(new[] { "test1", "test2" }),
                CreatedBy = Guid.NewGuid().ToString(),
                DocumentReceiveDate = "",
                DocumentTitle = "",
                DocumentTypeId = 0,
                DocumentUploadDate = "",
                FileDataList = new List<FileDetailsEntity>(),
                Note = ""
            };
            var cancellationToken = new CancellationToken();

            mockDocumentRepository.Setup(repo => repo.CreateDocument(It.IsAny<CreateDocumentCommand>())).ReturnsAsync(1);

            //Act
            var result = updateContactFlagHandler.Handle(createDocumentCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
