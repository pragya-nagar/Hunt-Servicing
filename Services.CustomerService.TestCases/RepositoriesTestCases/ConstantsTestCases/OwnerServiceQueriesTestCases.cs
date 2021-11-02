using Services.CustomerService.Repositories.Constants;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases.ConstantsTestCases
{
    public class OwnerServiceQueriesTestCases
    {
        [Fact]
        public void OwnerServiceQueriesData_ReturnsString()
        {
            //Arrange

            //Act
            string getOwnerByAssetIdQuery = OwnerServiceQueries.GetOwnerByAssetIdQuery;

            //Assert
            Assert.NotNull(getOwnerByAssetIdQuery);
            Assert.True(getOwnerByAssetIdQuery.Length > 0);
        }
    }
}
