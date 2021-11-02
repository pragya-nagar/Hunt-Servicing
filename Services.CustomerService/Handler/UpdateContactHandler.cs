using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// UpdateContactHandler
    /// </summary>
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        /// <summary>
        /// CreateContactHandler
        /// </summary>
        /// <param name="contactRepository"></param>
        public UpdateContactHandler(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            return await this._contactRepository.UpdateContact(request);
        }
    }
}
