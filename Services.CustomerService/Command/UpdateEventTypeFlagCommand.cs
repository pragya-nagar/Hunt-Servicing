using MediatR;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// UpdateEventTypeFlagCommand
    /// </summary>
    public class UpdateEventTypeFlagCommand : IRequest<int>
    {
        /// <summary>
        /// EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }
    }
}
