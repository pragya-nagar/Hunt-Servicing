using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// GlobalSearchOptionEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GlobalSearchOptionEntity : GlobalSearchOptionInputEntity
    {
        /// <summary>
        /// CellPhone
        /// </summary>
        [JsonProperty(PropertyName = "Phone Number")]
        [DisplayName("Phone Number")]
        public string CellPhone { get; set; }
        /// <summary>
        /// ContactPerson
        /// </summary>
        [JsonProperty(PropertyName = "Contact Name")]
        public string ContactPerson { get; set; }
    }
}
