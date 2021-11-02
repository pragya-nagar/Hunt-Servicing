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
    public class CreateContactHandlerTestCases
    {
        [Fact]
        public void HandleData_ByCreateContactHandlerAndCancellationToken_ReturnsInt()
        {
            //Arrange
            var mockContactRepository = new Mock<IContactRepository>();
            var updateContactFlagHandler = new CreateContactHandler(mockContactRepository.Object);

            var createContactCommand = new CreateContactCommand()
            {
                AssetId = new List<string>(new[] { "test1", "test2" }),
                CellPhone = "",
                Company = "",
                ContactAddress = "",
                ContactCityId = 0,
                ContactStateId = 0,
                ContactTypeId = 0,
                ContactZipCode = "",
                CreatedBy = Guid.NewGuid().ToString(),
                DoNotContactFlag = false,
                Email = "",
                Fax = "",
                FirstName = "",
                HomePhone = "",
                LastName = "",
                Note = "",
                WorkPhone = ""
            };
            var cancellationToken = new CancellationToken();

            mockContactRepository.Setup(repo => repo.CreateContact(It.IsAny<CreateContactCommand>())).ReturnsAsync(1);

            //Act
            var result = updateContactFlagHandler.Handle(createContactCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Result);
        }
    }
}
