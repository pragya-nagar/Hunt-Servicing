namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// EventRepositoryQueries
    /// </summary>
    public static class EventRepositoryQueries
    {
        /// <summary>
        /// UpdateHighlightedFlagByEventId
        /// </summary>
        public const string UpdateHighlightedFlagByEventId = "update public.\"Event\" set " +
            "\"HighLightFlag\" = \'1\' where \"EventId\" = @eventId";
        /// <summary>
        /// RemoveHighlightedFlagByEventId
        /// </summary>
        public const string RemoveHighlightedFlagByEventId = "update public.\"Event\" set " +
           "\"HighLightFlag\" = \'0\' where \"EventId\" = @eventId";
        /// <summary>
        /// GetAllEventType
        /// </summary>
        public const string GetAllEventType = "select distinct \"EventTypeId\", \"EventTypeName\" from" + "\"EventType\" where \"IsActive\" = true and \"IsDeleted\" = false order by 1";
        /// <summary>
        /// GetAllEventAction
        /// </summary>
        public const string GetAllEventAction = "select \"EventActionId\",\"EventActionName\",\"IsActionFlag\"" + " from \"EventAction\" where \"IsActive\" = true and \"IsDeleted\" = false order by 1";
        /// <summary>
        /// GetRelatedAsset
        /// </summary>
        public const string GetRelatedAsset = "public.\"GetRelatedAsset\"";
        /// <summary>
        /// GetContactByAssetId
        /// </summary>
        public const string GetContactByAssetId = "public.\"Get_ContactByAssetId\"";
        /// <summary>
        /// CreatedEvent
        /// </summary>
        public const string CreatedEvent = "public.\"CreateEvent\"";
        /// <summary>
        /// GetEventActionCategory
        /// </summary>
        public const string GetEventActionCategory = "select \"EventActionCategoryId\",\"EventActionCategoryName\" " +
            "from \"EventActionCategory\" where \"IsActive\" = true and \"IsDeleted\" = false order by 1";
        /// <summary>
        /// GetLienCountAssetDetails
        /// </summary>
        public const string GetLienCountAssetDetails = "public.\"GetLienCountAssetDetails\"";
    }
}
