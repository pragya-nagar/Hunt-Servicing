using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.CustomerService.Command;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel.DocumentViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Services.Common.Constants;
using Services.Common.S3Management.Interfaces;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// DocumentRepository
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ILogger _logger;
        /// <summary>
        /// _conn
        /// </summary>
        public string _conn { get; set; }
        /// <summary>
        /// _IFileManagement
        /// </summary>
        public IFileManagement _IFileManagement { get; set; }
        /// <summary>
        /// IFileManagement
        /// </summary>
        /// <param name="IFileManagement"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public DocumentRepository(IFileManagement IFileManagement, ILogger<DocumentRepository> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
            this._IFileManagement = IFileManagement;
        }
        /// <summary>
        /// GetOwnerListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentEntity>> GetDocumentListByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetDocumentListByAssetId() triggered to get owner by assetId");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = DocumentRepositoryConstant.GetDocumentList;
                    var parameters = new DynamicParameters();
                    parameters.Add("@assetId", assetId, DbType.String);
                    IEnumerable<DocumentEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<DocumentEntity>(sql, parameters);

                    if (result != null)
                    {
                        var documentListByAssetId = result.ToList();
                        {
                            var fileQuery = DocumentRepositoryConstant.GetDocumentFileList;
                            var parametersFile = new DynamicParameters();
                            foreach (var item in documentListByAssetId)
                            {

                                parametersFile.Add("@documentId", item.DocumentId);
                                item.UploadedFileNames = (await connection.QueryAsync<DocumentFileEntity>(fileQuery, parametersFile)).ToList();
                            }
                        }

                        return documentListByAssetId;
                    }
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetDocumentListByAssetId() in DocumentRepository with Message" + ex.Message);
                throw;
            }

            return null;
        }
        /// <summary>
        /// GetDocumentType
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentTypeEntity>> GetDocumentType()
        {
            try
            {
                this._logger.LogInformation("GetDocumentType() ");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = DocumentRepositoryConstant.GetDocumentType;

                    IEnumerable<DocumentTypeEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<DocumentTypeEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetDocumentType() in DocumentRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// UpdateDocumentFlagByDocumentId
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<int> UpdateDocumentFlagByDocumentId(int documentId, string assetId)
        {
            try
            {
                if (documentId > 0)
                {
                    this._logger.LogInformation("UpdateDocumentFlagByContactId() triggered to update Document flag");
                    string updateQuery = DocumentRepositoryConstant.UpdateIsDeletedFlagByDocumentId;
                    string deleteDocumentContact = DocumentRepositoryConstant.DeleteAssetDocumentByDocumentId;
                    string GetDocumentExist = DocumentRepositoryConstant.GetDocumentExist;
                    string DocumentFileByDocumentId = DocumentRepositoryConstant.DocumentFileByDocumentId;

                    string GetFilesByDocumentId = DocumentRepositoryConstant.GetFilesByDocumentId;
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@documentId", documentId);
                        parameters.Add("@assetId", assetId);
                        var parametersRemoveDocument = new DynamicParameters();
                        parametersRemoveDocument.Add("@documentId", documentId);

                        if (_conn != null)
                        {
                            var checkAssetCount = await conn.QueryFirstOrDefaultAsync<int>(GetDocumentExist, parameters);
                            this._logger.LogInformation("DeleteFileAsync() checkAssetCount:" + checkAssetCount);
                            if (checkAssetCount > 1)
                            {
                                await conn.QueryFirstOrDefaultAsync<int>(deleteDocumentContact, parameters);
                                this._logger.LogInformation("DeleteFileAsync() DeleteDcoument Success");
                            }
                            else
                            {
                                this._logger.LogInformation("DeleteFileAsync() else part start:");
                                var getFileList = await conn.QueryAsync<string>(GetFilesByDocumentId, parametersRemoveDocument);
                                this._logger.LogInformation("DeleteFileAsync() getFileList:" + getFileList);
                                foreach (var fileName in getFileList)
                                {
                                    this._logger.LogInformation("DeleteFileAsync() getFileList fileName:" + fileName);
                                    await this._IFileManagement.DeleteAsync(fileName);
                                    this._logger.LogInformation("DeleteFileAsync() finished");
                                }
                                this._logger.LogInformation("DeleteFileAsync() DeleteDocument start");
                                await conn.QueryFirstOrDefaultAsync<int>(deleteDocumentContact, parameters);
                                await conn.QueryFirstOrDefaultAsync<int>(updateQuery, parametersRemoveDocument);
                                await conn.QueryFirstOrDefaultAsync<int>(DocumentFileByDocumentId, parametersRemoveDocument);
                                this._logger.LogInformation("DeleteFileAsync() DeleteDocument end");
                            }
                        }
                        return 1;
                    }
                }
                else
                {
                    this._logger.LogInformation("Invalid Document ID found while executing UpdateDocumentFlagByDocumentId() in DocumentRepository");
                    return await Task.FromException<int>(new ArgumentException("Update failed ..."));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing UpdateDocumentFlagByContactId() in DocumentRepository with Message" + ex.Message);
                return await Task.FromException<int>(new ArgumentException("Update failed ..."));
            }
        }
        /// <summary>
        /// CreateDocument
        /// </summary>
        /// <param name="createDocumentCommand"></param>
        /// <returns></returns>
        public async Task<int> CreateDocument(CreateDocumentCommand createDocumentCommand)
        {
            try
            {
                this._logger.LogInformation("CreateDocument Upload files on S3");
                var uploadStatus = await this._IFileManagement.UploadDocumentToS3(createDocumentCommand.FileDataList);
                this._logger.LogInformation("CreateDocument Upload files on S3 Done");
                int result = 0;
                this._logger.LogInformation("CreateDocument Inserting data in Document table");

                if (!string.IsNullOrWhiteSpace(createDocumentCommand.DocumentTitle))
                {
                    using (var conn = new NpgsqlConnection(this._conn))
                    {
                        string sp = DocumentRepositoryConstant.CreateDocument;
                        var parameters = new DynamicParameters();
                        parameters.Add("@v_AssetId", createDocumentCommand.AssetId);
                        parameters.Add("@v_DocumentTypeId", createDocumentCommand.DocumentTypeId);
                        parameters.Add("@v_DocumentTitle", createDocumentCommand.DocumentTitle);
                        parameters.Add("@v_Note", createDocumentCommand.Note);
                        parameters.Add("@v_DocumentReceiveDate", createDocumentCommand.DocumentReceiveDate);
                        parameters.Add("@v_DocumentUploadDate", createDocumentCommand.DocumentUploadDate);
                        parameters.Add("@v_CreatedBy", createDocumentCommand.CreatedBy);
                        // Added for User Initial
                        parameters.Add("@v_CreatedByUserInitial", createDocumentCommand.CreatedByUserInitial);
                        parameters.Add("@v_UpdatedByUserInitial", createDocumentCommand.UpdatedByUserInitial);
                        if (_conn != null)
                            result = await conn.QueryFirstOrDefaultAsync<int>(sp, parameters, commandType: CommandType.StoredProcedure);
                    }
                }
                else
                {
                    this._logger.LogInformation("CreateDocument() in DocumentRepository");
                }


                if (uploadStatus.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in uploadStatus)
                    {
                        using (var conn = new NpgsqlConnection(this._conn))
                        {
                            string sp = DocumentRepositoryConstant.CreateDocumentFile;
                            var parameters = new DynamicParameters();
                            parameters.Add("@v_DocumentId", result);
                            parameters.Add("@v_UploadFileKey", kvp.Key);
                            parameters.Add("@v_UploadedFileName", kvp.Value);
                            parameters.Add("@v_CreatedBy", createDocumentCommand.CreatedBy);
                            // Added for User Initial
                            parameters.Add("@v_CreatedByUserInitial", createDocumentCommand.CreatedByUserInitial);
                            parameters.Add("@v_UpdatedByUserInitial", createDocumentCommand.UpdatedByUserInitial);

                            if (_conn != null)
                                await conn.QueryFirstOrDefaultAsync<int>(sp, parameters, commandType: CommandType.StoredProcedure);

                        }
                    }
                    this._logger.LogInformation("Data inserted in Document Details table");
                    return result;
                }
                else
                {
                    this._logger.LogInformation("CreateDocument() in DocumentRepository");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing CreateDocument() in DocumentRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// DownloadFileAsync
        /// </summary>
        /// <param name="documentFileId"></param>
        /// <returns></returns>
        public async Task<string> DownloadFileAsync(int documentFileId)
        {
            try
            {
                this._logger.LogInformation("DownloadFileAsync() triggered to DDownload Document");
                string GetDownloadFilesByDocumentId = DocumentRepositoryConstant.GetDownloadFilesByDocumentId;
                var data = string.Empty;
                using (var conn = new NpgsqlConnection(this._conn))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@documentFileId", documentFileId);
                    this._logger.LogInformation("DownloadFileAsync() documentFileId:" + documentFileId);
                    if (_conn != null)
                    {
                        var getFileList = await conn.QueryAsync<DocumentFileEntity>(GetDownloadFilesByDocumentId, parameters);
                        this._logger.LogInformation("DownloadFileAsync() getFileList:" + getFileList);
                        foreach (var fileName in getFileList)
                        {
                            this._logger.LogInformation("DownloadFileAsync() fileName:" + fileName.UploadedFileName);
                            data = await this._IFileManagement.GetFileData(fileName.UploadFileKey);
                            this._logger.LogInformation("DownloadFileAsync() data:" + data);
                        }
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing DownloadFileAsync() in DocumentRepository with Message" + ex.Message);
                return await Task.FromException<string>(new ArgumentException("DownloadFileAsync failed ..."));
            }
            
        }
    }
}
