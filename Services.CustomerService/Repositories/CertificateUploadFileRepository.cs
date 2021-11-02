using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.Common.Constants;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel.EventAssetViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Services.CustomerService.Command;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// This class used as repository of Certificate Upload File.
    /// </summary>
    public class CertificateUploadFileRepository : ICertificateUploadFileRepository
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// _conn
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public string _conn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateUploadFileRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        public CertificateUploadFileRepository(ILogger<CertificateUploadFileRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }

        /// <summary>
        /// This Method used t get uploaded file history list.
        /// </summary>
        /// <param name="certificateStatusId">The certificate status.</param>
        /// <returns>Uploaded file list.</returns>
        public async Task<IEnumerable<CertificateUploadFileHistory>> GetUploadFileHistoryList(int certificateStatusId)
        {
            try
            {
                _logger.LogInformation("GetUploadFileHistoryList() triggered to get uploaded file history data");
                using (var connection = new NpgsqlConnection(_conn))
                {
                    IEnumerable<CertificateUploadFileHistory> result = null;
                    const string sql = CertificateUploadFileQueries.GetCertificateFileHistoryList;
                    var parameters = new DynamicParameters();
                    certificateStatusId = certificateStatusId > -1 && certificateStatusId < 2 ? certificateStatusId : -1;
                    parameters.Add("@IsProcessed", certificateStatusId == -1 ? (bool?)null : Convert.ToBoolean(certificateStatusId), DbType.Boolean);
                    if (_conn != null)
                        result = await connection.QueryAsync<CertificateUploadFileHistory>(sql, parameters);

                    if (result != null)
                    {
                        var fileHistories = result.ToList();
                        fileHistories.ForEach(certificateFile =>
                        {
                            certificateFile.CertificateStatus = Enum.GetName(typeof(Enums.CertificateStatus), certificateFile.IsProcessed);
                        });

                        return fileHistories;
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing GetUploadFileHistoryList() in CertificateUploadFileRepository with Message" + ex.Message);
                throw;
            }
        }
       
        /// <summary>
        /// This method used to delete uploaded file by file id.
        /// </summary>
        /// <param name="uploadFileFlag">The uploaded file id.</param>
        /// <returns></returns>
        public async Task<int> DeleteUploadedFileByFileId(RemoveUploadFileFlagCommand uploadFileFlag)
        {
            try
            {
                var result = 0;
                if (uploadFileFlag.CertificateUploadFileId > 0)
                {
                    _logger.LogInformation("DeleteUploadedFileByFileId() triggered to set IsDeleted flag");
                    var updateQuery = CertificateUploadFileQueries.RemoveUploadedFileFlagByFileId;
                    using (var conn = new NpgsqlConnection(_conn))
                    {
                        if (_conn != null)
                            result = await conn.ExecuteAsync(updateQuery, new
                            {
                                uploadFileFlag.CertificateUploadFileId,
                                uploadFileFlag.UpdatedBy,
                                uploadFileFlag.UpdatedByUserInitial
                            });
                    }
                }

                _logger.LogInformation("Invalid certificateUploadFileId while executing DeleteUploadedFileByFileId() in CertificateUploadFileRepository.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Run time error while executing DeleteUploadedFileByFileId() in CertificateUploadFileRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
