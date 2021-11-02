using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// CreateEventHandler
    /// </summary>
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;
        /// <summary>
        /// CreateEventHandler
        /// </summary>
        /// <param name="eventRepository"></param>
        public CreateEventHandler(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            return await this._eventRepository.CreateEventId(request);
        }
    }
}
