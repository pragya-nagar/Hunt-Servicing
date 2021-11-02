namespace Services.CustomerService.Command
{
    /// <summary>
    /// PendingEventsActionCommand
    /// </summary>
    public class PendingEventsActionCommand
    {
        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// EventMasterId
        /// </summary>
        public int EventMasterId { get; set; }
        /// <summary>
        /// RejectedReason
        /// </summary>
        public string RejectedReason { get; set; }
    }
}
