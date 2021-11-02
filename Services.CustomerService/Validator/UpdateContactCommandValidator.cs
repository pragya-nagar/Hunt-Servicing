using FluentValidation;
using Services.CustomerService.Command;

namespace Services.CustomerService.Validator
{
    /// <summary>
    /// UpdateContactCommandValidator
    /// </summary>
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        /// <summary>
        /// FluentValidator
        /// </summary>
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("First Name is required").NotEmpty().WithMessage("First Name cannot be empty");
            RuleFor(x => x.LastName).NotNull().WithMessage("Last Name is required").NotEmpty().WithMessage("Last Name cannot be empty");
        }
    }
}
