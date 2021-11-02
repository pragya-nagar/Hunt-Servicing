using System;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// RecentEventsEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RecentEventsEntity : BaseEntity
    {
        /// <summary>
        /// EffectiveDate
        /// </summary>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// EventType
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// ActionCategory
        /// </summary>
        public string ActionCategory { get; set; }
        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Contact
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// User
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// EntryDate
        /// </summary>
        public DateTime EntryDate { get; set; }
        /// <summary>
        /// Flag
        /// </summary>
        public bool Flag { get; set; }
    }
}
