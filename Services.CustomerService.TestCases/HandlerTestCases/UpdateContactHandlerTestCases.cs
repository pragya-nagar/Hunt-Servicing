using System;
using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Handler;
using Services.CustomerService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Services.CustomerService.TestCases.HandlerTestCases
{
    public class UpdateContactHandlerTestCases
    {
        [Fact]
        public void HandleData_ByUpdateContactCommandAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var updateContactHandler = new UpdateContactHandler(mockContactRepository.Object);

            var listStr = new List<string> {"Test1"};
            var updateContactCommand = new UpdateContactCommand()
            {
                CellPhone = "",
                Company = "",
                ContactAddress = "",
                ContactCityId = 0,
                ContactStateId = 0,
                ContactTypeId = 0,
                ContactZipCode = "",
                DoNotContactFlag = false,
                Email = "",
                Fax = "",
                FirstName = "",
                HomePhone = "",
                LastName = "",
                Note = "",
                UpdatedBy = Guid.NewGuid().ToString(),
                WorkPhone = "",
                ContactId = -125,
                AssetId = listStr
            };
            var cancellationToken = new CancellationToken();

            mockContactRepository.Setup(repo => repo.UpdateContact(It.IsAny<UpdateContactCommand>())).ReturnsAsync(1);

            //Act
            var result = updateContactHandler.Handle(updateContactCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
