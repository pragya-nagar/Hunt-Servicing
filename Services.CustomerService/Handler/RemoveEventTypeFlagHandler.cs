using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// RemoveEventTypeFlagHandler
    /// </summary>
    public class RemoveEventTypeFlagHandler : IRequestHandler<RemoveEventTypeFlagCommand, int>
    {
        private readonly IEventRepository _eventRepository;
        /// <summary>
        /// RemoveEventTypeFlagHandler
        /// </summary>
        /// <param name="eventRepository"></param>
        public RemoveEventTypeFlagHandler(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(RemoveEventTypeFlagCommand request, CancellationToken cancellationToken)
        {
            return await this._eventRepository.RemoveEventTypeFlagByEventId(request.EventTypeId);
        }
    }
}
