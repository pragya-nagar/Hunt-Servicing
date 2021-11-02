using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// CreateContactHandler
    /// </summary>
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        /// <summary>
        /// CreateContactHandler
        /// </summary>
        /// <param name="contactRepository"></param>
        public CreateContactHandler(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            return await this._contactRepository.CreateContact(request);
        }
    }
}
