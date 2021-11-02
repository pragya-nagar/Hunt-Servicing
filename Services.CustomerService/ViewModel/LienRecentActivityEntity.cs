using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// LienRecentActivityEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LienRecentActivityEntity
    {
        /// <summary>
        /// EventId
        /// </summary>
        public int EventId { get; set; }
        /// <summary>
        /// EffectiveDate
        /// </summary>
        public string EffectiveDate { get; set; }
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
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// EntryStamp
        /// </summary>
        public string EnteryStamp { get; set; }
        /// <summary>
        /// Flag
        /// </summary>
        public bool Flag { get; set; }
        /// <summary>
        /// CreatedByUserInitial
        /// </summary>
        public string CreatedByUserInitial { get; set; }
        /// <summary>
        /// UpdatedByUserInitial
        /// </summary>
        public string UpdatedByUserInitial { get; set; }
    }
}
