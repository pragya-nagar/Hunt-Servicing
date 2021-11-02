using MediatR;
using System.Collections.Generic;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// RejectedEventsActionEntityCommand
    /// </summary>
    public class RejectedEventsActionCommand : IRequest<int>
    {
        /// <summary>
        /// ApprovedList
        /// </summary>
        public int[] ApprovedList { get; set; }
        /// <summary>
        /// PendingList
        /// </summary>
        public int[] PendingList { get; set; }
        /// <summary>
        /// DeletedList
        /// </summary>
        public int[] DeletedList { get; set; }
        /// <summary>
        /// RejectedList
        /// </summary>
        public List<RejectedListProp> RejectedList { get; set; }
    }
    /// <summary>
    /// RejectedListProp
    /// </summary>
    public class RejectedListProp
    {
        /// <summary>
        /// RejectedReason
        /// </summary>
        public int RejectedReason { get; set; }
        /// <summary>
        /// EventMasterId
        /// </summary>
        public int EventMasterId { get; set; }
    }
}
