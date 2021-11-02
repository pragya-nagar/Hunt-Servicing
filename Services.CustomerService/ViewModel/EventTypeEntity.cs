using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// EventTypeEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EventTypeEntity
    {
        /// <summary>
        /// EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }
        /// <summary>
        /// EventTypeName
        /// </summary>
        public string EventTypeName { get; set; }
    }
}
