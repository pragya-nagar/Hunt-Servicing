using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel
{
    /// <summary>
    /// StateListEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StateListEntity
    {
        /// <summary>
        /// StateName
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// StateCode
        /// </summary>
        public string StateCode { get; set; }
        /// <summary>
        /// StateId
        /// </summary>
        public int StateId { get; set; }
    }
}
