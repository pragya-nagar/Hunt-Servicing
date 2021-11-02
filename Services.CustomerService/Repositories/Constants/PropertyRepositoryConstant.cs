namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// PropertyRepositoryConstant
    /// </summary>
    public static class PropertyRepositoryConstant
    {
        /// <summary>
        /// GetContactType
        /// </summary>
        public const string GetParcelInfoByAssetId = "select PD.\"ParcelId\", PD.\"AlternateParcelId1\", PD.\"AlternateParcelId2\", " +
                                                     "PD.\"AlternateParcelId3\", PD.\"PropertyAddress\", PD.\"PropertyZipCode\", " +
                                                     "PD.\"LandUseCode\", PD.\"GeneralLandUseCode\", PD.\"LegalDescription\", PD.\"LandValue\", PD.\"ImprovementValue\", PD.\"AssessedValue\", COALESCE(ST.\"StateName\",'') as \"StateName\", COALESCE(C.\"CityName\", '') as \"CityName\" " +
                                                     "from \"PropertyDetails\" PD " +
                                                     "inner join \"AssetProperty\" AP on PD.\"ParcelId\" = AP.\"ParcelId\" " +
                                                     "left join \"City\" C on PD.\"PropertyCityId\" = C.\"CityId\" " +
                                                     "left join \"State\" ST on PD.\"PropertyStateId\" = ST.\"StateId\" " +
                                                     "where PD.\"IsActive\" = true and PD.\"IsDeleted\" = false and AP.\"AssetId\" = @assetId";
        /// <summary>
        /// GetPropertyListByAssetId
        /// </summary>
        public const string GetPropertyListByAssetId = "select \"PD\".\"ParcelId\", \"PD\".\"PropertyAddress\", \"PD\".\"PropertyZipCode\", " +
                                                       "\"PD\".\"LandUseCode\", \"PD\".\"GeneralLandUseCode\", \"PD\".\"LegalDescription\", \"PD\".\"LandValue\", \"PD\".\"ImprovementValue\", \"PD\".\"AssessedValue\", " +
                                                       "COALESCE(\"C\".\"CityName\", '') \"CityName\", COALESCE(\"S\".\"StateName\", '') \"StateName\" " +
                                                       "from \"AssetProperty\" \"APO\" " +
                                                       "inner join \"PropertyDetails\" \"PD\" on \"APO\".\"PropertyId\" = \"PD\".\"PropertyId\" " +
                                                       "left join \"City\" \"C\" on \"C\".\"CityId\" = \"PD\".\"PropertyCityId\" " +
                                                       "left join \"State\" \"S\" on \"S\".\"StateId\" = \"PD\".\"PropertyStateId\" " +
                                                       "where \"APO\".\"AssetId\" = @assetId";
    }
}
