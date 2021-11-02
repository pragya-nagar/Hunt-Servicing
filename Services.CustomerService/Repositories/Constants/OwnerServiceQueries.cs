namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// OwnerServiceQueries
    /// </summary>
    public static class OwnerServiceQueries
    {
        /// <summary>
        /// GetOwnerByAssetIdQuery
        /// </summary>
        public const string GetOwnerByAssetIdQuery = "select \"O\".\"OwnerName\",\"O\".\"OwnerAddress\", COALESCE(\"C\".\"CityName\", '') \"OwnerCity\",\"S\".\"StateName\" as \"OwnerState\"," +
                       "\"O\".\"OwnerZipCode\",\"O\".\"OwnerSocialSecurityNo\",\"O\".\"OwnerTaxId\",to_char(\"O\".\"OwnerDob\",'MM-DD-YYYY') as \"OwnerDob\"" +
                                                    " from \"OwnerDetails\" as \"O\"" +
                                                    "inner join \"AssetPropertyOwner\" \"APO\" on \"O\".\"OwnerId\" = \"APO\".\"OwnerId\"" +
                                                    "inner join \"State\" \"S\" on \"O\".\"OwnerStateId\" = \"S\".\"StateId\"" +
                                                    "left join \"City\" \"C\" on \"C\".\"CityId\" = \"O\".\"OwnerCityId\" "+
                                                    "where \"APO\".\"AssetId\"= @assetId ";

    }
}
