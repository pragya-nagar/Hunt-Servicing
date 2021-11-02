using Services.CustomerService.ViewModel.OwnerViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// IOwnerRepository
    /// </summary>
    public interface IOwnerRepository
    {
        /// <summary>
        /// GetOwnerListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<OwnerEntity>> GetOwnerListByAssetId(string assetId);
    }
}
