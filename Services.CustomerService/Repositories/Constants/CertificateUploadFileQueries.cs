namespace Services.CustomerService.Repositories.Constants
{
    /// <summary>
    /// CertificateUploadFileQueries
    /// </summary>
    public static class CertificateUploadFileQueries
    {
        /// <summary>
        /// The get certificate file history list
        /// </summary>
        public const string GetCertificateFileHistoryList = "SELECT \"CertificateUploadFileId\", \"CertificateUploadFileName\", \"TotalRecordUploaded\", \"IsProcessed\", " +
                                                            "to_char(\"CreatedDate\",'MM-DD-YYYY HH:MI AM') as \"UploadedDate\", " +
                                                            "to_char(\"CertificateGeneratedDate\",'MM-DD-YYYY HH:MI AM') as \"CertificateGeneratedDate\", " +
                                                            "\"CreatedByUserInitial\", \"UpdatedByUserInitial\" " +
                                                            "FROM public.\"CertificateUploadFileHistory\" " +
                                                            "where \"IsActive\"= true AND \"IsDeleted\" = false " +
                                                            "AND ((\"IsProcessed\" = cast (@IsProcessed as bool) and @IsProcessed is not null) " +
                                                            "OR (\"IsProcessed\" is not null and @IsProcessed is null)) " +
                                                            "Order by \"CertificateUploadFileId\" asc";

        /// <summary>
        /// The remove uploaded file flag by file id
        /// </summary>
        public const string RemoveUploadedFileFlagByFileId = "update public.\"CertificateUploadFileHistory\" " +
                                                             "set \"IsDeleted\" = true, \"UpdatedBy\" = @UpdatedBy::uuid, \"UpdatedByUserInitial\" = @UpdatedByUserInitial " +
                                                             "where \"CertificateUploadFileId\" = @CertificateUploadFileId";
    }
}
