using Services.CustomerService.Repositories.Constants;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases.ConstantsTestCases
{
    public class ContactServiceQueriesTestCases
    {
        [Fact]
        public void ContactServiceQueriesData_ReturnsString()
        {
            //Arrange

            //Act
            string getContactByAssetIdQuery = ContactServiceQueries.GetContactByAssetIdQuery;
            string getContactType = ContactServiceQueries.GetContactType;
            string updateIsDeletedFlagByContactId = ContactServiceQueries.UpdateIsDeletedFlagByContactId;
            string createContact = ContactServiceQueries.CreateContact;
            string getCityByStateId = ContactServiceQueries.GetCityByStateId;

            //Assert
            Assert.NotNull(getContactByAssetIdQuery);
            Assert.NotNull(getContactType);
            Assert.NotNull(updateIsDeletedFlagByContactId);
            Assert.NotNull(createContact);
            Assert.NotNull(getCityByStateId);

            Assert.True(getContactByAssetIdQuery.Length > 0);
            Assert.True(getContactType.Length > 0);
            Assert.True(updateIsDeletedFlagByContactId.Length > 0);
            Assert.True(createContact.Length > 0);
            Assert.True(getCityByStateId.Length > 0);
        }
    }
}
