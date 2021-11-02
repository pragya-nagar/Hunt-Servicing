using System.Diagnostics.CodeAnalysis;

namespace Services.CustomerService.ViewModel.PropertyViewModel
{
    /// <summary>
    /// PropertyDetailsViewModel
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PropertyDetailsEntity
    {
        /// <summary>
        /// ParcelId
        /// </summary>
        public string ParcelId { get; set; }
        /// <summary>
        /// AlternateParcelId1
        /// </summary>
        public string AlternateParcelId1 { get; set; }
        /// <summary>
        /// AlternateParcelId2
        /// </summary>
        public string AlternateParcelId2 { get; set; }
        /// <summary>
        /// AlternateParcelId3
        /// </summary>
        public string AlternateParcelId3 { get; set; }
        /// <summary>
        /// PropertyAddress
        /// </summary>
        public string PropertyAddress { get; set; }
        /// <summary>
        /// PropertyCity
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// PropertyStateId
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// PropertyZipCode
        /// </summary>
        public string PropertyZipCode { get; set; }
        /// <summary>
        /// LandUseCode
        /// </summary>
        public string LandUseCode { get; set; }
        /// <summary>
        /// GeneralLandUseCode
        /// </summary>
        public string GeneralLandUseCode { get; set; }
        /// <summary>
        /// LegalDescription
        /// </summary>
        public string LegalDescription { get; set; }
        /// <summary>
        /// LandValue
        /// </summary>
        public string LandValue { get; set; }
        /// <summary>
        /// ImprovementValue
        /// </summary>
        public string ImprovementValue { get; set; }
        /// <summary>
        /// AssessedValue
        /// </summary>
        public string AssessedValue { get; set; }
    }
}
