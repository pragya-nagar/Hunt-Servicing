using FluentValidation;
using Services.CustomerService.ViewModel;

namespace Services.CustomerService.Validator
{
    /// <summary>
    /// GlobalSearchOptionInputAdvancedEntityValidator
    /// </summary>
    public class GlobalSearchOptionInputAdvancedEntityValidator : AbstractValidator<GlobalSearchOptionInputAdvancedEntity>
    {
        /// <summary>
        /// FluentValidator
        /// </summary>
        public GlobalSearchOptionInputAdvancedEntityValidator()
        {
            RuleFor(x => x.StateId).NotNull().WithMessage("State Id is required");
        }
    }
}
