using FluentValidation.TestHelper;
using Services.CustomerService.Validator;
using Xunit;

namespace Services.CustomerService.TestCases.ValidatorTestCases
{
    public class CreateEventCommandValidatorTestCases
    {
        private readonly CreateEventCommandValidator validator;
        public CreateEventCommandValidatorTestCases()
        {
            //Assert
            validator = new CreateEventCommandValidator();
        }

        [Fact]
        public void CreateEventCommandValidator_ByDefault_ReturnsValidationsError()
        {
            //Act & Assert
            validator.ShouldHaveValidationErrorFor(eventCommand => eventCommand.EventTypeId, 0);
            validator.ShouldHaveValidationErrorFor(eventCommand => eventCommand.ActionId, 0);
            validator.ShouldHaveValidationErrorFor(eventCommand => eventCommand.ActionCategory, 0);
            //validator.ShouldHaveValidationErrorFor(eventCommand => eventCommand.EventDate, null);
            validator.ShouldHaveValidationErrorFor(eventCommand => eventCommand.Note, "");
        }

        [Fact]
        public void CreateEventCommandValidator_ByDefault_ReturnsValidationsSuccess()
        {
            //Act & Assert
            validator.ShouldNotHaveValidationErrorFor(eventCommand => eventCommand.EventTypeId, 10);
            validator.ShouldNotHaveValidationErrorFor(eventCommand => eventCommand.ActionId, 10);
            validator.ShouldNotHaveValidationErrorFor(eventCommand => eventCommand.ActionCategory, 10);
            //validator.ShouldNotHaveValidationErrorFor(eventCommand => eventCommand.EventDate, );
            validator.ShouldNotHaveValidationErrorFor(eventCommand => eventCommand.Note, "TestString");
        }
    }
}
