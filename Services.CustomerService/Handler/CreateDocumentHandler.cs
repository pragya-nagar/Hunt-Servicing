using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, int>
    {
        private readonly IDocumentRepository _documentRepository;
        /// <summary>
        /// CreateDocumentHandler
        /// </summary>
        /// <param name="documentRepository"></param>
        public CreateDocumentHandler(IDocumentRepository documentRepository)
        {
            this._documentRepository = documentRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            return await this._documentRepository.CreateDocument(request);
        }
    }
}
