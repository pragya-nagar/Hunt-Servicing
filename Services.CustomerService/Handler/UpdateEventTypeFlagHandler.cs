using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// UpdateEventTypeFlagHandler
    /// </summary>
    public class UpdateEventTypeFlagHandler : IRequestHandler<UpdateEventTypeFlagCommand, int>
    {
        private readonly IEventRepository _eventRepository;
        /// <summary>
        /// UpdateEventTypeFlagHandler
        /// </summary>
        /// <param name="eventRepository"></param>
        public UpdateEventTypeFlagHandler(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(UpdateEventTypeFlagCommand request, CancellationToken cancellationToken)
        {
            return await this._eventRepository.UpdateEventTypeFlagByEventId(request.EventTypeId);
        }
    }
}
