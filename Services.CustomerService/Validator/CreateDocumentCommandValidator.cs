using FluentValidation;
using Services.CustomerService.Command;

namespace Services.CustomerService.Validator
{
    ///
    public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
    {
        /// <summary>
        /// FluentValidator
        /// </summary>
        public CreateDocumentCommandValidator()
        {
            RuleFor(x => x.DocumentTypeId).NotNull().WithMessage("Document Type is required").NotEmpty().WithMessage("Document Type cannot be empty");
            RuleFor(x => x.DocumentTitle).NotNull().WithMessage("Document Title is required").NotEmpty().WithMessage("Document Title cannot be empty");
            RuleFor(x => x.DocumentReceiveDate).NotNull().WithMessage("Document Receive Date is required").NotEmpty().WithMessage("Document Receive Date cannot be empty");
            RuleFor(x => x.DocumentUploadDate).NotNull().WithMessage("Document Upload Date is required").NotEmpty().WithMessage("Document Upload Date cannot be empty");
        }
    }
}
