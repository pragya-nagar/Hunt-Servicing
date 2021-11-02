using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Common.Constants;
using Services.Common.Entity;
using Services.Common.S3Management.Interfaces;

namespace Services.Common.S3Management
{
    /// <summary>
    /// FileManagement
    /// </summary>
    public class FileManagement : IFileManagement
    {
        /// <summary>
        /// The amazon s3
        /// </summary>
        private readonly IAmazonS3 _amazonS3;
        
        /// <summary>
        /// The bucket name
        /// </summary>
        private readonly string _bucketName;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<FileManagement> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="FileManagement" /> class.
        /// </summary>
        /// <param name="amazonS3">The amazon s3.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public FileManagement(IAmazonS3 amazonS3, IConfiguration configuration, ILogger<FileManagement> logger)
        {
            _amazonS3 = amazonS3;
            _bucketName = configuration["BucketName"];
            _logger = logger;
        }

        /// <summary>
        /// UploadDocumentToS3
        /// </summary>
        /// <param name="FileDataList"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> UploadDocumentToS3(List<FileDetailsEntity> FileDataList)
        {
            this._logger.LogInformation("DeleteFileAsync() folder create start");
            if (!IsFolderExists(_bucketName, AppSettingConstants.S3FolderName))
            {
                this._logger.LogInformation("CreateFolder() start");
                CreateFolder(_bucketName, AppSettingConstants.S3FolderName).GetAwaiter().GetResult();
            }

            var Result = new Dictionary<string, string>();
            try
            {
                var FileGuid = Guid.NewGuid();
                foreach (var fileDataList in FileDataList)
                {
                    this._logger.LogInformation(" UploadDocumentToS3FileDataList start");
                    byte[] bytes = Convert.FromBase64String(fileDataList.FileData);
                    using (var stream = new MemoryStream(bytes))
                    {
                        var fileNameWithGuid = FileGuid + fileDataList.FileName;
                        this._logger.LogInformation(" UploadDocumentToS3 fileNameWithGuid:" + fileNameWithGuid);
                        var request = new PutObjectRequest
                        {
                            BucketName = _bucketName,
                            Key = AppSettingConstants.S3FolderPath + fileNameWithGuid,
                            InputStream = stream,
                            CannedACL = S3CannedACL.Private
                        };
                        this._logger.LogInformation(" UploadDocumentToS3 PutObjectRequest:" + request.BucketName);
                        this._logger.LogInformation("UploadDocumentToS3 PutObjectRequest:" + request.Key);

                        if (!string.IsNullOrWhiteSpace(_bucketName))
                        {
                            await _amazonS3.PutObjectAsync(request);
                            var filePath = fileNameWithGuid;
                            Result.Add(filePath, fileDataList.FileName);
                            this._logger.LogInformation("UploadDocumentToS3 PutObjectRequest Result:" + Result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Document Upload Failed" + e.Message + e.StackTrace);
                throw;
            }
            return Result;
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteAsync(string fileName, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                this._logger.LogInformation("DeleteFileAsync() start");
                var request = new DeleteObjectRequest
                {
                    BucketName = _bucketName,
                    Key = AppSettingConstants.S3FolderPath + fileName,
                };
                this._logger.LogInformation("DeleteFileAsync() request: " + request.BucketName);
                this._logger.LogInformation("DeleteFileAsync() request: " + request.Key);
                return this._amazonS3.DeleteObjectAsync(request, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Image Delete Failed" + e.Message + e.StackTrace);
                throw;
            }
        }
        /// <summary>
        /// GetImageData
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string> GetFileData(string key)
        {
            this._logger.LogInformation("GetFileData Start");
            string res;
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = _bucketName,
                    Key = AppSettingConstants.S3FolderPath + key
                };
                this._logger.LogInformation("GetFileData Start GetObjectRequest:" + request.Key);
                this._logger.LogInformation("GetFileData Start GetObjectRequest:" + request.BucketName);
                using (GetObjectResponse response = await _amazonS3.GetObjectAsync(request))
                {
                    this._logger.LogInformation("GetFileData GetObjectResponse start");
                    this._logger.LogInformation($"GetFileData AWS response :  {response}" + response.ContentLength);
                    using (Stream responseStream = response.ResponseStream)
                    using (MemoryStream stream = new MemoryStream())
                    {
                        this._logger.LogInformation($"ResponseStream :  {responseStream}" + responseStream.Length);
                        await responseStream.CopyToAsync(stream);
                        stream.Position = 0;
                        this._logger.LogInformation($"Stream :  {stream.ToArray()}" + stream.ToArray().Length);
                        res = Convert.ToBase64String(stream.ToArray());
                        this._logger.LogInformation("Response Base64 :  " + res);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("GetImageData Error: " + e.Message + e.StackTrace);
                throw;
            }
            return res;
        }
        /// <summary>
        /// IsFolderExists
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsFolderExists(string bucket, string path)
        {
            this._logger.LogInformation("IsFolderExists() start");
            ListObjectsRequest findFolderRequest = new ListObjectsRequest();
            this._logger.LogInformation("IsFolderExists() BucketName: " + bucket);
            findFolderRequest.BucketName = bucket;
            this._logger.LogInformation("IsFolderExists() path: " + path);
            findFolderRequest.Prefix = path;
            Task<ListObjectsResponse> findFolderResponse = _amazonS3.ListObjectsAsync(findFolderRequest);
            this._logger.LogInformation("IsFolderExists() findFolderResponse: " + findFolderResponse);
            Boolean folderExists = findFolderResponse.Result.S3Objects.Any();
            this._logger.LogInformation("IsFolderExists() folderExists: " + folderExists);
            return folderExists;
        }
        public Task<PutObjectResponse> CreateFolder(string bucket, string folder)
        {
            this._logger.LogInformation("Inside CreateFolder()");
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = _bucketName,
                Key = folder
            };
            this._logger.LogInformation("CreateFolder() PutObjectRequest: " + request.BucketName);
            this._logger.LogInformation("CreateFolder() PutObjectRequest: " + request.Key);

            Task<PutObjectResponse> response = _amazonS3.PutObjectAsync(request);
            this._logger.LogInformation("CreateFolder() response: " + response);
            return response;
        }
    }
}