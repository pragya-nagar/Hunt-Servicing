using Services.CustomerService.Command;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.ContactViewModel
{
    /// <summary>
    /// ManageContact
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ManageContact
    {
        /// <summary>
        /// createContactCommand
        /// </summary>
        public CreateContactCommand createContactCommand { get; set; }
        /// <summary>
        /// AssetId
        /// </summary>
        public List<string> AssetId { get; set; }
    }
}
