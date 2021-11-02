using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// BaseEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BaseEntity
    {
        /// <summary>
        /// AssetID
        /// </summary>
        [JsonProperty(PropertyName = "Asset ID")]
        [DisplayName("Asset ID")]
        public string AssetID { get; set; }
    }
}
