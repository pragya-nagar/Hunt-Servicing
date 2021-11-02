using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories;
using System;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases
{
    public class ContactRepositoryTestCases
    {
        readonly ContactRepository contactRepository;

        public ContactRepositoryTestCases()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<ContactRepository>>();
            var mockIConfiguration = new Mock<IConfiguration>();
            contactRepository = new ContactRepository(mockLogger.Object, mockIConfiguration.Object);
        }

        [Fact]
        public void GetContactList_ByAssetId_ReturnsContactDetailsEntity()
        {
            //Arrange
            contactRepository._conn = null;

            //Act
            var result = contactRepository.GetContactListByAssetId("");

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetContactTypeList_ByDefault_ReturnsContactTypeEntity()
        {
            //Arrange
            contactRepository._conn = null;

            //Act
            var result = contactRepository.GetContactTypeList();

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void UpdateContactFlag_ByContactId_ReturnsInt()
        {
            //Arrange
            contactRepository._conn = null;

            //Act
            var result = contactRepository.UpdateContactFlagByContactId(10);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void CreateContactFlag_ByContactId_ReturnsInt()
        {
            //Arrange
            contactRepository._conn = null;

            //Act
            var result = contactRepository.CreateContactFlagByContactId(10);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void CreateContact_ByCreateContactCommand_ReturnsInt()
        {
            //Arrange
            contactRepository._conn = null;

            var createContactCommand = new CreateContactCommand()
            {
                FirstName = "Test"
            };

            //Act
            var result = contactRepository.CreateContact(createContactCommand);

            //Assert
            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void GetCityList_ByStateId_ReturnsCityEntity()
        {
            //Arrange
            contactRepository._conn = null;

            //Act
            var result = contactRepository.GetCityList(10);

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetContact_ByContactId_ReturnsManageContact()
        {
            //Arrange
            contactRepository._conn = null;

            //Act
            var result = contactRepository.GetContactByContactId(10);

            //Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public void UpdateContact_ByUpdateContactCommand_ReturnsInt()
        {
            //Arrange
            contactRepository._conn = null;

            var updateContactCommand = new UpdateContactCommand()
            {
                FirstName = "Test"
            };

            //Act
            var result = contactRepository.UpdateContact(updateContactCommand);

            //Assert
            Assert.Equal(0, result.Result);
        }
        [Fact]
        public async System.Threading.Tasks.Task GetContactList_ByAssetId_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.GetContactListByAssetId(""));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetContactTypeList_ByDefault_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.GetContactTypeList());
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateContactFlag_ByContactId_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.UpdateContactFlagByContactId(10));
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateContactFlag_ByContactId_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.CreateContactFlagByContactId(10));
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateContact_ByCreateContactCommand_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            var createContactCommand = new CreateContactCommand()
            {
                FirstName = "Test"
            };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.CreateContact(createContactCommand));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCityList_ByStateId_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.GetCityList(10));
        }

        [Fact]
        public async System.Threading.Tasks.Task GetContact_ByContactId_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.GetContactByContactId(10));
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateContact_ByUpdateContactCommand_ReturnsArgumentException()
        {
            //Arrange
            contactRepository._conn = "Test";

            var updateContactCommand = new UpdateContactCommand()
            {
                FirstName = "Test"
            };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => contactRepository.UpdateContact(updateContactCommand));
        }
    }
}
