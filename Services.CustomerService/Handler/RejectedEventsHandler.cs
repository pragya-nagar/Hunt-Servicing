using MediatR;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.CustomerService.Handler
{
    /// <summary>
    /// RejectedEventsHandler
    /// </summary>
    public class RejectedEventsHandler : IRequestHandler<RejectedEventsActionCommand, int>
    {
        private readonly IEventAssetRepository _IEventAssetRepository;
        /// <summary>
        /// RejectedEventsHandler
        /// </summary>
        /// <param name="eventAssetRepository"></param>
        public RejectedEventsHandler(IEventAssetRepository eventAssetRepository)
        {
            this._IEventAssetRepository = eventAssetRepository;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(RejectedEventsActionCommand request, CancellationToken cancellationToken)
        {
            return await _IEventAssetRepository.RejectedEventsAction(request);
        }
    }
}
