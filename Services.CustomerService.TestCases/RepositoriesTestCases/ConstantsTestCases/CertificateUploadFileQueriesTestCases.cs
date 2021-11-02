using Services.CustomerService.Repositories.Constants;
using Xunit;

namespace Services.CustomerService.TestCases.RepositoriesTestCases.ConstantsTestCases
{
    public class CertificateUploadFileQueriesTestCases
    {
        [Fact]
        public void CertificateUploadFileQueries_ReturnsString()
        {
            //Arrange

            //Act
            string certificateFileHistoryList = CertificateUploadFileQueries.GetCertificateFileHistoryList;

            //Assert
            Assert.NotNull(certificateFileHistoryList);
            Assert.True(certificateFileHistoryList.Length > 0);
        }

        [Fact]
        public void RemoveUploadedFileFlagByFileIdQueries_ReturnsString()
        {
            //Arrange

            //Act
            string removeUploadedFileFlagByFileId = CertificateUploadFileQueries.RemoveUploadedFileFlagByFileId;

            //Assert
            Assert.NotNull(removeUploadedFileFlagByFileId);
            Assert.True(removeUploadedFileFlagByFileId.Length > 0);
        }
    }
}
