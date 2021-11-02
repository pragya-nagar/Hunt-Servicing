using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Services.Common.Entity;

namespace Services.Common.S3Management.Interfaces
{
    /// <summary>
    /// IFileManagement
    /// </summary>
    public interface IFileManagement
    {
        /// <summary>
        /// UploadDocumentToS3
        /// </summary>
        /// <param name="FileDataList"></param>
        /// <returns></returns>
        Task<Dictionary<string, string>> UploadDocumentToS3(List<FileDetailsEntity> FileDataList);
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(string fileName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// GetImageData
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> GetFileData(string key);
        /// <summary>
        /// IsFolderExists
        /// </summary>
        /// <param name="bucket">The bucket.</param>
        /// <param name="path">The path.</param>
        /// <returns>
        ///   <c>true</c> if [is folder exists] [the specified bucket]; otherwise, <c>false</c>.
        /// </returns>
        bool IsFolderExists(string bucket, string path);
        /// <summary>
        /// CreateFolder
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        Task<PutObjectResponse> CreateFolder(string bucket, string folder);
    }
}
