using FluentValidation.TestHelper;
using Services.CustomerService.Validator;
using Xunit;

namespace Services.CustomerService.TestCases.ValidatorTestCases
{
    public class UpdateContactCommandValidatorTestCases
    {
        private readonly UpdateContactCommandValidator validator;
        public UpdateContactCommandValidatorTestCases()
        {
            //Assert
            validator = new UpdateContactCommandValidator();
        }

        [Fact]
        public void UpdateContactCommandValidator_ByDefault_ReturnsValidationsError()
        {
            //Act & Assert
            validator.ShouldHaveValidationErrorFor(contact => contact.FirstName, null as string);
            validator.ShouldHaveValidationErrorFor(contact => contact.LastName, "");
        }

        [Fact]
        public void UpdateContactCommandValidator_ByDefault_ReturnsValidationsSuccess()
        {
            //Act & Assert
            validator.ShouldNotHaveValidationErrorFor(contact => contact.FirstName, "TestString");
            validator.ShouldNotHaveValidationErrorFor(contact => contact.LastName, "TestString");
        }
    }
}
