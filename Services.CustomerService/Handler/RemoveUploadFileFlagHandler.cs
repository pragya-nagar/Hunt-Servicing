using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// RemoveUploadFileFlag Handler
    /// </summary>
    public class RemoveUploadFileFlagHandler : IRequestHandler<RemoveUploadFileFlagCommand, int>
    {
        /// <summary>
        /// The certificate upload file repository
        /// </summary>
        private readonly ICertificateUploadFileRepository _certificateUploadFileRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveUploadFileFlagHandler"/> class.
        /// </summary>
        /// <param name="certificateUploadFileRepository">The certificate upload file repository.</param>
        public RemoveUploadFileFlagHandler(ICertificateUploadFileRepository certificateUploadFileRepository)
        {
            _certificateUploadFileRepository = certificateUploadFileRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<int> Handle(RemoveUploadFileFlagCommand request, CancellationToken cancellationToken)
        {
            return await _certificateUploadFileRepository.DeleteUploadedFileByFileId(request);
        }
    }
}
