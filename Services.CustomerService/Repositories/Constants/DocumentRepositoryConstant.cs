namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// DocumentRepositoryConstant
    /// </summary>
    public static class DocumentRepositoryConstant
    {
        /// <summary>
        /// GetDocumentList
        /// </summary>
        public const string GetDocumentList = "select \"AD\".\"AssetId\",\"D\".\"DocumentId\", " +
            "(case when(\"D\".\"DocumentTypeId\" is not null and \"D\".\"DocumentTypeId\" > 0) then " +
            "(select \"DocumentTypeName\" from \"DocumentType\" where \"DocumentTypeId\" = \"D\".\"DocumentTypeId\") else '' end) as \"DocumentType\", " +
            "\"D\".\"DocumentTitle\",\"D\".\"Note\",to_char(\"D\".\"DocumentReceiveDate\",'MM-DD-YYYY') as \"DocumentReceiveDate\"," +
            "to_char(\"D\".\"DocumentUploadDate\",'MM-DD-YYYY HH24:MI PM') as \"DocumentUploadDate\",\"D\".\"CreatedByUserInitial\", \"D\".\"UpdatedByUserInitial\" " +
            "from \"Document\" \"D\" " +
            "inner join \"AssetDocument\" \"AD\" on \"D\".\"DocumentId\" = \"AD\".\"DocumentId\" " +
            "where \"AD\".\"AssetId\" = @assetId and \"D\".\"IsDeleted\" = false and \"AD\".\"PrimaryAssetFlag\" = false order by \"DocumentId\" desc ";
        /// <summary>
        /// GetDocumentFileList
        /// </summary>
        public const string GetDocumentFileList = "select \"UploadedFileName\",\"DocumentFileId\" from \"DocumentFile\" where \"DocumentId\" = @documentId";
        /// <summary>
        /// GetDocumentType
        /// </summary>
        public const string GetDocumentType = "select \"DocumentTypeId\",\"DocumentTypeName\" from \"DocumentType\" where \"IsDeleted\" = false";
        /// <summary>
        /// UpdateIsDeletedFlagByDocumentId
        /// </summary>
        public const string UpdateIsDeletedFlagByDocumentId = "update public.\"Document\" set \"IsDeleted\" = true where \"DocumentId\" = @documentId";
        /// <summary>
        /// DeleteAssetDocumentByDocumentId
        /// </summary>
        public const string DeleteAssetDocumentByDocumentId = "update public.\"AssetDocument\" set \"PrimaryAssetFlag\" = true where \"DocumentId\" = @documentId and \"AssetId\" = @assetId";
        /// <summary>
        /// CreateDocument
        /// </summary>
        public const string CreateDocument = "public.\"CreateDocument\"";

        /// <summary>
        /// CreateDocumentFile
        /// </summary>
        public const string CreateDocumentFile = "public.\"CreateDocumentFile\"";
        /// <summary>
        /// GetDocumentExist
        /// </summary>
        public const string GetDocumentExist = "select count(\"AssetId\") from \"AssetDocument\" where \"AssetId\" = @assetId and \"DocumentId\" = @documentId and \"PrimaryAssetFlag\" = false";
        /// <summary>
        /// DocumentFileByDocumentId
        /// </summary>
        public const string DocumentFileByDocumentId = "update public.\"DocumentFile\" set \"IsDeleted\" = true where \"DocumentId\" = @documentId";
        /// <summary>
        /// 
        /// </summary>
        public const string GetFilesByDocumentId = "select \"UploadFileKey\" from \"DocumentFile\" where \"DocumentId\" = @documentId";

        /// <summary>
        /// 
        /// </summary>
        public const string GetDownloadFilesByDocumentId = "select \"UploadedFileName\", \"UploadFileKey\" from \"DocumentFile\" where \"DocumentFileId\" = @documentFileId";
    }
}