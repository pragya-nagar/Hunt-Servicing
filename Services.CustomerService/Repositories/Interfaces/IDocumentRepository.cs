using Services.CustomerService.Command;
using Services.CustomerService.ViewModel.DocumentViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// IDocumentRepository
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// GetDocumentListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<DocumentEntity>> GetDocumentListByAssetId(string assetId);
        /// <summary>
        /// GetDocumentType
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DocumentTypeEntity>> GetDocumentType();
        /// <summary>
        /// UpdateDocumentFlagByDocumentId
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<int> UpdateDocumentFlagByDocumentId(int documentId, string assetId);
        /// <summary>
        /// CreateDocument
        /// </summary>
        /// <param name="createDocumentCommand"></param>
        /// <returns></returns>
        Task<int> CreateDocument(CreateDocumentCommand createDocumentCommand);
        /// <summary>
        /// DownloadFileAsync
        /// </summary>
        /// <param name="documentFileId"></param>
        /// <returns></returns>
        Task<string> DownloadFileAsync(int documentFileId);
    }
}
