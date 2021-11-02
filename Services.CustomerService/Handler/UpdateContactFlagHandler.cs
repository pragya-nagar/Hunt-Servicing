using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// UpdateContactFlagHandler
    /// </summary>
    public class UpdateContactFlagHandler : IRequestHandler<UpdateContactFlagCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        /// <summary>
        /// UpdateContactFlagHandler
        /// </summary>
        /// <param name="contactRepository"></param>
        public UpdateContactFlagHandler(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(UpdateContactFlagCommand request, CancellationToken cancellationToken)
        {
            return await this._contactRepository.UpdateContactFlagByContactId(request.ContactId);
        }
    }
}
