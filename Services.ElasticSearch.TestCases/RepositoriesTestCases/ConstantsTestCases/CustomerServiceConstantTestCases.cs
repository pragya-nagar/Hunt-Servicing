using Services.Common.Constants;
using Xunit;

namespace Services.ElasticSearch.TestCases.RepositoriesTestCases.ConstantsTestCases
{
    public class CustomerServiceConstantTestCases
    {
        [Fact]
        public void ElsConfigAdvanceIndexGetPropertyTests()
        {
            var query = AppSettingConstants.ElsConfigAdvanceIndex;
            Assert.True(query.Length > 0);
        }

        [Fact]
        public void ElsConfigGlobalIndexGetPropertyTests()
        {
            var query = AppSettingConstants.ElsConfigGlobalIndex;
            Assert.True(query.Length > 0);
        }

        [Fact]
        public void ElsConfigUrlGetPropertyTests()
        {
            var query = AppSettingConstants.ElsConfigUrl;
            Assert.True(query.Length > 0);
        }
    }
}
