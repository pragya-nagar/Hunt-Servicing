using System.Collections.Generic;

namespace Services.CustomerService.TestCases.MockData
{
    public static class MockRepoData
    {
        public static Dictionary<string, string> MockDictionary()
        {
            var TestDic = new Dictionary<string, string> {{"TestFile", "TestPath"}};
            return TestDic;
        }
    }
}
