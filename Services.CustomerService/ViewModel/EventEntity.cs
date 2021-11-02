using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// EventEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EventEntity
    {
        /// <summary>
        /// EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }
        /// <summary>
        /// ActionId
        /// </summary>
        public int ActionId { get; set; }
        /// <summary>
        /// ActionCategory
        /// </summary>
        public string ActionCategory { get; set; }
        /// <summary>
        /// EventDate
        /// </summary>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// ContactId
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public List<int> AssetId { get; set; }
        /// <summary>
        /// HighLightFlag
        /// </summary>
        public bool HighLightFlag { get; set; }
    }
}
