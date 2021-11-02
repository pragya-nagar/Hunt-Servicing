using FluentValidation;
using Services.CustomerService.Command;

namespace Services.CustomerService.Validator
{
    /// <summary>
    /// UpdateContactCommandValidator
    /// </summary>
    public class RemoveUploadFileFlagCommandValidator : AbstractValidator<RemoveUploadFileFlagCommand>
    {
        /// <summary>
        /// FluentValidator
        /// </summary>
        public RemoveUploadFileFlagCommandValidator()
        {
            RuleFor(x => x.CertificateUploadFileId)
                .NotNull().WithMessage("CertificateUploadFileId is required.")
                .GreaterThan(0).WithMessage("CertificateUploadFileId should be greater than is 1.");

            RuleFor(x => x.UpdatedByUserInitial)
                .NotNull().WithMessage("UpdatedByUserInitial is required.")
                .NotEmpty().WithMessage("UpdatedByUserInitial is required.");

            RuleFor(x => x.UpdatedBy)
                .NotNull().WithMessage("UpdatedBy is required.")
                .NotEmpty().WithMessage("UpdatedBy is required.");
        }
    }
}
