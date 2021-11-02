using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// EventActionEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EventActionEntity
    {
        /// <summary>
        /// EventActionId
        /// </summary>
        public int EventActionId { get; set; }
        /// <summary>
        /// EventActionName
        /// </summary>
        public string EventActionName { get; set; }
        /// <summary>
        /// Action flag
        /// </summary>
        public bool IsActionflag { get; set; }
    }
}
