using MediatR;
using Services.Common.Entity;
using System.Collections.Generic;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// CreateDocumentCommand
    /// </summary>
    public class CreateDocumentCommand : IRequest<int>
    {
        /// <summary>
        /// AssetId
        /// </summary>
        public List<string> AssetId { get; set; }
        /// <summary>
        /// DocumentTypeId
        /// </summary>
        public int DocumentTypeId { get; set; }
        /// <summary>
        /// DocumentTitle
        /// </summary>
        public string DocumentTitle { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// DocumentReceiveDate
        /// </summary>
        public string DocumentReceiveDate { get; set; }
        /// <summary>
        /// DocumentUploadDate
        /// </summary>
        public string DocumentUploadDate { get; set; }
        
        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// FileDataList
        /// </summary>
        public List<FileDetailsEntity> FileDataList { get; set; }

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

