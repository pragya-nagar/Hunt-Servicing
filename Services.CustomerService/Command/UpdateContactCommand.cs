using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.CustomerService.Command
{
    /// <summary>
    /// UpdateContactCommand
    /// </summary>
    public class UpdateContactCommand : IRequest<int>
    {
        /// <summary>
        /// ContactId
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// ContactAddress
        /// </summary>
        public string ContactAddress { get; set; }
        /// <summary>
        /// ContactCityId
        /// </summary>
        public int ContactCityId { get; set; }
        /// <summary>
        /// ContactStateId
        /// </summary>
        public int ContactStateId { get; set; }
        /// <summary>
        /// ContactZipCode
        /// </summary>
        public string ContactZipCode { get; set; }
        /// <summary>
        /// ContactTypeId
        /// </summary>
        public int ContactTypeId { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// CellPhone
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// HomePhone
        /// </summary>
        public string HomePhone { get; set; }
        /// <summary>
        /// WorkPhone
        /// </summary>
        public string WorkPhone { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// DoNotContactFlag
        /// </summary>
        public bool DoNotContactFlag { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public List<string> AssetId { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
