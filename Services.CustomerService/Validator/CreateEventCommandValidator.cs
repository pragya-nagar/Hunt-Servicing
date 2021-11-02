using FluentValidation;
using Services.CustomerService.Command;

namespace Services.CustomerService.Validator
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        /// <summary>
        /// FluentValidator
        /// </summary>
        public CreateEventCommandValidator()
        {
            RuleFor(x => x.EventTypeId).NotNull().WithMessage("Event Type is required").NotEmpty().WithMessage("Event Type cannot be empty").GreaterThan(0).WithMessage("Event Type cannot be less then 0");
            RuleFor(x => x.ActionId).NotNull().WithMessage("Action is required").NotEmpty().WithMessage("Action cannot be empty").GreaterThan(0).WithMessage("Event Type cannot be less then 0");
            RuleFor(x => x.ActionCategory).NotNull().WithMessage("Action Category is required").NotEmpty().WithMessage("Action Category cannot be empty").GreaterThan(0).WithMessage("Action Category cannot be less then 0");
            RuleFor(x => x.EventDate).NotNull().WithMessage("Event Date is required").NotEmpty().WithMessage("Event Date cannot be empty");
            RuleFor(x => x.Note).NotNull().WithMessage("Note is required").NotEmpty().WithMessage("Note cannot be empty");
        }
    }
}
