namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// PendingEventsQueries
    /// </summary>
    public static class PendingEventsQueries
    {
        /// <summary>
        /// GetRejectReason
        /// </summary>
        public const string GetRejectReason = "select \"EventMasterRejectionReasonId\",\"EventMasterRejectionReasonName\" from \"EventMasterRejectionReason\" " +
                                        "where \"IsActive\" = true and \"IsDeleted\" = false order by 1 desc";
        /// <summary>
        /// 
        /// </summary>
        public const string GetMasterEvents = "public.\"GetMasterEvents\"";

        /// <summary>
        /// RemoveEventMaster
        /// </summary>
        public const string RemoveEventMaster = "update \"EventMaster\" set \"IsDeleted\" = true,\"UpdatedDate\" = now() where \"EventMasterId\" = @eventMasterId and \"IsActive\" = true and \"IsDeleted\" = false ";

        /// <summary>
        /// ModifyEventMasterFromRejectedToPending
        /// </summary>
        public const string ModifyEventMasterFromRejectedToPending = "update \"EventMaster\" set \"EventMasterStatusId\" = 1,\"RejectedDate\" = null,\"UpdatedDate\" = now() where \"EventMasterId\" = @eventMasterId and \"IsActive\" = true and \"IsDeleted\" = false";
        /// <summary>
        /// ApprovedEventMaster
        /// </summary>
        public const string ApprovedEventMaster = "update \"EventMaster\" set \"EventMasterStatusId\" = 2,\"ApprovedDate\" = now() ,\"UpdatedDate\" = now() where \"EventMasterId\" = @eventMasterId and \"IsActive\" = true and \"IsDeleted\" = false";
        /// <summary>
        /// ApprovedEventMaster
        /// </summary>
        public const string RejectedEventMaster = "update \"EventMaster\" set \"EventMasterStatusId\" = 3,\"RejectedDate\" = now(),\"EventMasterRejectionReasonId\" = @rejectedReason,\"UpdatedDate\" = now()  where \"EventMasterId\" = @eventMasterId and \"IsActive\" = true and \"IsDeleted\" = false";

        /// <summary>
        /// EventDetailsHeaderQuery
        /// </summary>
        public const string EventDetailsHeaderQuery =
            "select \"EventId\",to_char(cast(\"AcquisitionDate\" as date),'MM/DD/YYYY') as \"AcquisitionDate\",\"Jurisdiction\",\"FinancingGroup\" " +
                "from \"EventMaster\" " +
                "where \"EventId\" = @eventId " +
                "and \"IsActive\" = true and \"IsDeleted\" = false";
        /// <summary>
        /// EventDetailsQuery
        /// </summary>
        public const string EventDetailsQuery =
            "select \"EM\".\"EventMasterId\",\"EM\".\"EventId\", " +
            "(select \"StateCode\" from \"State\" where \"StateId\" = \"EM\".\"StateId\") as \"StateCode\",\"EM\".\"Jurisdiction\", " +
            "\"EM\".\"FinancingGroup\",\"EM\".\"PurchasingEntity\",\"EM\".\"LienHierarchy\", " +
            "\"EM\".\"TotalInterestPenalty\",\"EM\".\"TotalTaxAmount\", " +
            "\"EM\".\"TotalOverbid\",\"EM\".\"TotalPremium\",\"EM\".\"TotalPurchase\",\"EM\".\"TotalFee\", " +
            "(select count(\"EventMasterId\") from \"EventMasterAsset\" where \"EventMasterId\" = \"EM\".\"EventMasterId\") as \"TotalAssets\", " +
            "to_char(\"EM\".\"ApprovedDate\", 'MM-DD-YYYY') as \"ApprovedDate\", " +
            "to_char(cast(\"EM\".\"AcquisitionDate\" as date), 'MM/DD/YYYY') as \"AcquisitionDate\" " +
            "from \"EventMaster\" \"EM\" " +
            "where \"EM\".\"EventId\" = @eventId " +
            "and \"EM\".\"IsActive\" = true and \"EM\".\"IsDeleted\" = false";
        /// <summary>
        /// EventDetailsAssetListQuery
        /// </summary>
        public const string EventDetailsAssetListQuery =
            "select distinct(\"EMA\".\"AssetId\"),\"EM\".\"Jurisdiction\",\"AD\".\"AssetName\",\"AP\".\"ParcelId\", " +
                 "STRING_AGG('''' || " +
                 "((case when (\"PD\".\"PropertyAddress\" is not null and \"PD\".\"PropertyAddress\" <> '') " +
                "then \"PD\".\"PropertyAddress\" || ' ' else '' end)   || (case when(\"PD\".\"PropertyCityId\" is not null " +
                "and \"PD\".\"PropertyCityId\" > 0) then(select \"CityName\" || ', ' from \"City\" where \"CityId\" = " +
            " \"PD\".\"PropertyCityId\" ) else '' end) ||  " +
                " (case when(\"PD\".\"PropertyStateId\" is not null and \"PD\".\"PropertyStateId\" > 0) then " +
                " (select \"StateName\" || ' ' from \"State\" where \"StateId\" = \"PD\".\"PropertyStateId\") else '' end) " +
            "|| \"PD\".\"PropertyZipCode\") || '''',',') as \"PropertyAddress\" " +
                "from \"EventMaster\" \"EM\" " +
                "inner join \"EventMasterAsset\" \"EMA\" on \"EM\".\"EventMasterId\" = \"EMA\".\"EventMasterId\" " +
                "inner join \"AssetDetail\" \"AD\" on \"EMA\".\"AssetId\" = \"AD\".\"AssetId\" " +
                "inner join \"AssetProperty\" \"AP\" on \"AD\".\"AssetId\" = \"AP\".\"AssetId\" " +
                " inner join \"PropertyDetails\" \"PD\" on \"AP\".\"PropertyId\" = \"PD\".\"PropertyId\" " +
                " where \"EM\".\"EventId\" = @eventId " +
                " and \"EM\".\"IsActive\" = true and \"EM\".\"IsDeleted\" = false " +
                " group by \"EMA\".\"AssetId\",\"EM\".\"Jurisdiction\",\"AD\".\"AssetName\",\"AP\".\"ParcelId\" " +
                "order by 1 desc";
    }
}
