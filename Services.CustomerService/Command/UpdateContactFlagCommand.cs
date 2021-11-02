using MediatR;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// UpdateContactFlagCommand
    /// </summary>
    public class UpdateContactFlagCommand : IRequest<int>
    {
        /// <summary>
        /// ContactId
        /// </summary>
        public int ContactId { get; set; }
    }
}
