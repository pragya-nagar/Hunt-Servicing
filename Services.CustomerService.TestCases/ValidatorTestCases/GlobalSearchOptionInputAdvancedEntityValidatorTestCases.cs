using FluentValidation.TestHelper;
using Services.CustomerService.Validator;
using Xunit;

namespace Services.CustomerService.TestCases.ValidatorTestCases
{
    public class GlobalSearchOptionInputAdvancedEntityValidatorTestCases
    {
        private readonly GlobalSearchOptionInputAdvancedEntityValidator validator;
        public GlobalSearchOptionInputAdvancedEntityValidatorTestCases()
        {
            //Assert
            validator = new GlobalSearchOptionInputAdvancedEntityValidator();
        }

        [Fact]
        public void GlobalSearchOptionInputAdvancedEntityValidator_ByDefault_ReturnsValidationsError()
        {
            //Act & Assert
            //validator.ShouldHaveValidationErrorFor(search => search.StateId, 0);
        }

        [Fact]
        public void GlobalSearchOptionInputAdvancedEntityValidator_ByDefault_ReturnsValidationsSuccess()
        {
            //Act & Assert
            validator.ShouldNotHaveValidationErrorFor(search => search.StateId , 10);
        }
    }
}
