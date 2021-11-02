using FluentValidation.TestHelper;
using Services.CustomerService.Validator;
using Xunit;

namespace Services.CustomerService.TestCases.ValidatorTestCases
{
    public class RemoveUploadFileFlagCommandValidatorTestCases
    {
        private readonly RemoveUploadFileFlagCommandValidator validator;

        public RemoveUploadFileFlagCommandValidatorTestCases()
        {
            //Assert
            validator = new RemoveUploadFileFlagCommandValidator();
        }

        [Fact]
        public void RemoveUploadFileFlagCommandValidator_ReturnsValidationsError()
        {
            //Act & Assert
            validator.ShouldHaveValidationErrorFor(cuf => cuf.CertificateUploadFileId, 0);
        }

        [Fact]
        public void RemoveUploadFileFlagCommandValidator_ReturnsValidationsSuccess()
        {
            //Act & Assert
            validator.ShouldNotHaveValidationErrorFor(cuf => cuf.CertificateUploadFileId, 1);
        }
    }
}
