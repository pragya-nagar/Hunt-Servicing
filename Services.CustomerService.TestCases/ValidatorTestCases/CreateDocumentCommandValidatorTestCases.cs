using FluentValidation.TestHelper;
using Services.CustomerService.Validator;
using Xunit;

namespace Services.CustomerService.TestCases.ValidatorTestCases
{
    public class CreateDocumentCommandValidatorTestCases
    {
        private readonly CreateDocumentCommandValidator validator;
        public CreateDocumentCommandValidatorTestCases()
        {
            //Assert
            validator = new CreateDocumentCommandValidator();
        }

        [Fact]
        public void CreateDocumentCommandValidator_ByDefault_ReturnsValidationsError()
        {
            //Act & Assert
            //validator.ShouldHaveValidationErrorFor(document => document.DocumentTypeId, 0);
            validator.ShouldHaveValidationErrorFor(document => document.DocumentTitle, null as string);
            validator.ShouldHaveValidationErrorFor(document => document.DocumentReceiveDate, "");
            validator.ShouldHaveValidationErrorFor(document => document.DocumentUploadDate, null as string);

        }

        [Fact]
        public void CreateDocumentCommandValidator_ByDefault_ReturnsValidationsSuccess()
        {
            //Act & Assert
            //validator.ShouldNotHaveValidationErrorFor(document => document.DocumentTypeId, 10);
            validator.ShouldNotHaveValidationErrorFor(document => document.DocumentTitle, "TestString");
            validator.ShouldNotHaveValidationErrorFor(document => document.DocumentReceiveDate, "TestString");
            validator.ShouldNotHaveValidationErrorFor(document => document.DocumentUploadDate, "TestString");
        }
    }
}
