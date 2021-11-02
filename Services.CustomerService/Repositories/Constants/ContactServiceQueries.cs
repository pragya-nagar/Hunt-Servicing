namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// ContactServiceQueries
    /// </summary>
    public static class ContactServiceQueries
    {
        /// <summary>
        /// GetOwnerByAssetIdQuery
        /// </summary>
        public const string GetContactByAssetIdQuery = "select (\"C\".\"FirstName\"|| ' '|| \"C\".\"LastName\") as \"Name\", " +
                            "(case when(\"C\".\"ContactTypeId\" is not null and \"C\".\"ContactTypeId\" > 0) " +  
                            " then (select \"TypeName\" from \"ContactType\" where \"ContactTypeId\" = \"C\".\"ContactTypeId\") else '' end) as \"TypeName\", " +
                            " \"C\".\"Company\", " + 
                            " rtrim(((case when (\"C\".\"ContactAddress\" is not null and \"C\".\"ContactAddress\" <> '') then \"C\".\"ContactAddress\" || ' ' else '' end)  " +
                            " || (case when(\"C\".\"ContactCityId\" is not null and \"C\".\"ContactCityId\" > 0) then " +
                            " (select \"CityName\" || ', ' from \"City\" where \"CityId\" = \"C\".\"ContactCityId\" ) else '' end) || " +
                            " (case when(\"C\".\"ContactStateId\" is not null and \"C\".\"ContactStateId\" > 0) then " +
                            " (select \"StateName\" || ' ' from \"State\" where \"StateId\" = \"C\".\"ContactStateId\") else '' end) || \"C\".\"ContactZipCode\"),',') as \"ContactAddress\", " +
                            " \"C\".\"CellPhone\",\"C\".\"DoNotContactFlag\",\"C\".\"ContactId\" from \"Contact\" \"C\" " +
                            " inner join \"AssetContact\" \"AC\" on \"C\".\"ContactId\" = \"AC\".\"ContactId\" " +
                            " where \"AC\".\"AssetId\" = @assetId "+
                            " and \"C\".\"IsActive\" = true and \"C\".\"IsDeleted\" = false and \"AC\".\"PrimaryAssetFlag\" = false order by \"C\".\"ContactId\" desc";
        /// <summary>
        /// GetContactType
        /// </summary>
        public const string GetContactType = "SELECT \"ContactTypeId\", \"TypeName\"" +
                                             "from public.\"ContactType\" " +
                                             "where \"IsActive\" = true and \"IsDeleted\" = false";
        /// <summary>
        /// UpdateIsDeletedFlagByContactId
        /// </summary>
        public const string UpdateIsDeletedFlagByContactId = "update public.\"Contact\" set \"IsDeleted\" = true where \"ContactId\" = @ContactId";
        /// <summary>
        /// DeleteAssetContactByContactId
        /// </summary>
        public const string DeleteAssetContactByContactId = "update public.\"AssetContact\" set \"PrimaryAssetFlag\" = true where \"ContactId\" = @ContactId";
        /// <summary>
        /// CreateContact
        /// </summary>
        public const string CreateContact = "public.\"CreateContact\"";
        /// <summary>
        /// GetCityByStateId
        /// </summary>
        public const string GetCityByStateId = "select \"CityName\", \"CityId\" from \"City\" where \"StateId\" = @stateId order by 1";
        /// <summary>
        /// getContactByContactId
        /// </summary>
        public const string getContactByContactId = "select \"ContactId\", \"FirstName\",\"LastName\",\"ContactAddress\"," +
            "\"ContactStateId\",\"ContactCityId\",\"ContactZipCode\",\"ContactTypeId\",\"Company\"," +
            "\"CellPhone\",\"WorkPhone\",\"HomePhone\",\"Fax\",\"Email\",\"DoNotContactFlag\",\"Note\"" +
            "from \"Contact\" where \"ContactId\" = @contactId and \"IsDeleted\" = false and \"IsActive\" = true";
        /// <summary>
        /// getRelatedAssetByContactId
        /// </summary>
        public const string getRelatedAssetByContactId = "select \"AssetId\" from \"AssetContact\" where \"ContactId\" = @contactId";
        /// <summary>
        /// UpdateContact
        /// </summary>
        public const string UpdateContact = "public.\"UpdateContact\"";
    }
}