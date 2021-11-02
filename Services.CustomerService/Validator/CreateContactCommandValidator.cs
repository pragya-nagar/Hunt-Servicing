using FluentValidation;
using Services.CustomerService.Command;

namespace Services.CustomerService.Validator
{
    /// <summary>
    /// FluentValidator
    /// </summary>
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        /// <summary>
        /// FluentValidator
        /// </summary>
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("First Name is required").NotEmpty().WithMessage("First Name cannot be empty");
            RuleFor(x => x.LastName).NotNull().WithMessage("Last Name is required").NotEmpty().WithMessage("Last Name cannot be empty");
        }
    }
}
