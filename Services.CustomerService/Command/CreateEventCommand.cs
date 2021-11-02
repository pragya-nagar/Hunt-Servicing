using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// CreateEventCommand
    /// </summary>
    public class CreateEventCommand : IRequest<int>
    {
        /// <summary>
        /// EventTypeId
        /// </summary>
        [Required]
        public int EventTypeId { get; set; }
        /// <summary>
        /// ActionId
        /// </summary>
        [Required]
        public int ActionId { get; set; }
        /// <summary>
        /// ActionCategory
        /// </summary>
        [Required]
        public int ActionCategory { get; set; }
        /// <summary>
        /// EventDate
        /// </summary>
        [Required]
        public DateTime EventDate { get; set; }
        /// <summary>
        /// ContactId
        /// </summary>
        [Required]
        public int ContactId { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        [Required]
        public string Note { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        [Required]
        public string CreatedBy { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        [Required]
        public List<string> AssetId { get; set; }
        /// <summary>
        /// HighLightFlag
        /// </summary>
        [Required]
        public bool HighLightFlag { get; set; }

        /* Added for User Initial */

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
