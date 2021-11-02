using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// RemoveEventTypeFlagCommand
    /// </summary>
    public class RemoveEventTypeFlagCommand : IRequest<int>
    {
        /// <summary>
        /// EventTypeId
        /// </summary>
        [Required]
        public int EventTypeId { get; set; }
    }
}
