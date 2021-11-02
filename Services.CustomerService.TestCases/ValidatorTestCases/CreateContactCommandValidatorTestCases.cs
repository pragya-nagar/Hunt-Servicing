using FluentValidation.TestHelper;
using Services.CustomerService.Validator;
using Xunit;

namespace Services.CustomerService.TestCases.ValidatorTestCases
{
    public class CreateContactCommandValidatorTestCases
    {
        private readonly CreateContactCommandValidator validator;
        public CreateContactCommandValidatorTestCases()
        {
            //Assert
            validator = new CreateContactCommandValidator();
        }

        [Fact]
        public void CreateContactCommandValidator_ByDefault_ReturnsValidationsError()
        {
            //Act & Assert
            validator.ShouldHaveValidationErrorFor(contact => contact.FirstName, null as string);
            validator.ShouldHaveValidationErrorFor(contact => contact.LastName, "");
        }

        [Fact]
        public void CreateContactCommandValidator_ByDefault_ReturnsValidationsSuccess()
        {
            //Act & Assert
            validator.ShouldNotHaveValidationErrorFor(contact => contact.FirstName, "TestString");
            validator.ShouldNotHaveValidationErrorFor(contact => contact.LastName, "TestString");
        }
    }
}
