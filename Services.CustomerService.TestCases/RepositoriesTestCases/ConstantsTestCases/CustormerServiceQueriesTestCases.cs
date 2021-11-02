using Services.CustomerService.Repositories.Constants;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases.ConstantsTestCases
{
    public class CustomerServiceQueriesTestCases
    {
        [Fact]
        public void CustomerServiceQueriesData_ReturnsString()
        {
            //Arrange

            //Act
            string getStatus = CustomerServiceQueries.GetStates;
            string queryAssetStatus = CustomerServiceQueries.QueryAssetStatus;
            string getGlobalPopUpSearchResultByParcelId = CustomerServiceQueries.GetGlobalPopUpSearchResultByParcelId;
            string getGlobalPopUpSearchResultByParcelIdAndAssetId = CustomerServiceQueries.GetGlobalPopUpSearchResultByParcelIdAndAssetId;
            string getGlobalSearchSPAdvanced = CustomerServiceQueries.GetGlobalSearchSPAdvanced;
            string getGlobalSearchSP = CustomerServiceQueries.GetGlobalSearchSP;
            string getLienAssetInfo = CustomerServiceQueries.GetLienAssetInfo;
            string getLienHeaderInfoQuery = CustomerServiceQueries.GetLienHeaderInfoQuery;
            string getLienRecentActivityInfo = CustomerServiceQueries.GetLienRecentActivityInfo;
            string getEventTypeByAssetId = CustomerServiceQueries.GetEventTypeByAssetId;
            string getFlagActionByAssetId = CustomerServiceQueries.GetFlagActionByAssetId;
            string getOtherActionByAssetId = CustomerServiceQueries.GetOtherActionByAssetId;
            
            //Assert
            Assert.NotNull(getStatus);
            Assert.NotNull(queryAssetStatus);
            Assert.NotNull(getGlobalPopUpSearchResultByParcelId);
            Assert.NotNull(getGlobalPopUpSearchResultByParcelIdAndAssetId);
            Assert.NotNull(getGlobalSearchSPAdvanced);
            Assert.NotNull(getGlobalSearchSP);
            Assert.NotNull(getLienAssetInfo);
            Assert.NotNull(getLienHeaderInfoQuery);
            Assert.NotNull(getLienRecentActivityInfo);
            Assert.NotNull(getEventTypeByAssetId);
            Assert.NotNull(getFlagActionByAssetId);
            Assert.NotNull(getOtherActionByAssetId);

            Assert.True(getStatus.Length>0);
            Assert.True(queryAssetStatus.Length>0);
            Assert.True(getGlobalPopUpSearchResultByParcelId.Length>0);
            Assert.True(getGlobalPopUpSearchResultByParcelIdAndAssetId.Length>0);
            Assert.True(getGlobalSearchSPAdvanced.Length>0);
            Assert.True(getGlobalSearchSP.Length>0);
            Assert.True(getLienAssetInfo.Length>0);
            Assert.True(getLienHeaderInfoQuery.Length>0);
            Assert.True(getLienRecentActivityInfo.Length>0);
            Assert.True(getEventTypeByAssetId.Length>0);
            Assert.True(getFlagActionByAssetId.Length>0);
            Assert.True(getOtherActionByAssetId.Length>0);
        }
    }
}
