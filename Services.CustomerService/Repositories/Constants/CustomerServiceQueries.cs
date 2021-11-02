namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// CustomerServiceQueries
    /// </summary>
    public static class CustomerServiceQueries
    {
        /// <summary>
        /// GetStates
        /// </summary>
        public const string GetStates = "select * from public.\"State\" where \"StateId\" in (select distinct \"StateId\" from public.\"AssetDetail\") or \"StateId\" = 0 order by 1";
        /// <summary>
        /// QueryAssetStatus
        /// </summary>
        public const string QueryAssetStatus = "select * from public.\"AssetStatus\" where \"IsActive\" = true and \"IsDeleted\" = false order by 1";
        /// <summary>
        /// GetGlobalPopUpSearchResultByParcelId
        /// </summary>
        public const string GetGlobalPopUpSearchResultByParcelId = "public.\"Get_GlobalPopUpSearchResultByParcelId\"";
        /// <summary>
        /// GetGlobalPopUpSearchResultByParcelIdAndAssetId
        /// </summary>
        public const string GetGlobalPopUpSearchResultByParcelIdAndAssetId = "public.\"GetGlobalPopUpSearchResultByParcelIdAndAssetId\"";
        /// <summary>
        /// GetGlobalSearchSPAdvanced
        /// </summary>
        public const string GetGlobalSearchSPAdvanced = "public.\"Get_GlobalSearchResultAdvanced\"";
        /// <summary>
        /// GetGlobalSearchSP
        /// </summary>
        public const string GetGlobalSearchSP = "public.\"Get_GlobalSearchResult\"";
        /// <summary>
        /// GetLienAssetInfo
        /// </summary>
        public const string GetLienAssetInfo = "public.\"Get_LienAssetInfo\"";
        /// <summary>
        /// GetLienHeaderInfoQuery
        /// </summary>
        public const string GetLienHeaderInfoQuery = "select (case when (\"APO\".\"OwnerId\" is not null and \"APO\".\"OwnerId\" > 0) " +
                                                     "then (select \"OwnerName\" from \"OwnerDetails\" where \"OwnerId\" = \"APO\".\"OwnerId\" limit 1) " +
                                                     "else '' end) as \"AssetName\", \r\n\"PD\".\"PropertyAddress\", \"APO\".\"AssetId\", \"PT\".\"PropertyTypeName\" " +
                                                     "from \"AssetPropertyOwner\" \"APO\" \r\ninner join \"PropertyDetails\" \"PD\" on \"APO\".\"PropertyId\" = \"PD\".\"PropertyId\" " +
                                                     "inner join \"PropertyType\" \"PT\" on \"PD\".\"PropertyTypeId\" = \"PT\".\"PropertyTypeId\" " +
                                                     "where \"APO\".\"AssetId\" = @assetId and \"PropertyOwnerFlag\" = false " +
                                                     "and \"PD\".\"IsActive\"= true and \"PD\".\"IsDeleted\"= false  " +
                                                     "and \"PT\".\"IsActive\"= true and \"PT\".\"IsDeleted\"= false";
        /// <summary>
        /// GetLienRecentActivityInfo
        /// </summary>
        public const string GetLienRecentActivityInfo = "public.\"Get_EventAndNotes\"";
        /// <summary>
        /// GetEventTypeByAssetId
        /// </summary>
        public const string GetEventTypeByAssetId = "public.\"Get_EventTypeByAssetId\"";
        /// <summary>
        /// GetFlagActionByAssetId
        /// </summary>
        public const string GetFlagActionByAssetId = "public.\"Get_FlagActionByAssetId\"";
        /// <summary>
        /// GetOtherActionByAssetId
        /// </summary>
        public const string GetOtherActionByAssetId = "public.\"Get_OtherActionByAssetId\"";
        
    }
}
