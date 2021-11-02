using Services.CustomerService.ViewModel.PropertyViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CustomerService.Repositories.Interfaces
{
    /// <summary>
    /// IPropertyRepository
    /// </summary>
    public interface IPropertyRepository
    {
        /// <summary>
        /// GetPropertyInfoByParcelId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<PropertyDetailsEntity>> GetPropertyInfoByAssetId(string assetId);
        /// <summary>
        /// GetPropertyListByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        Task<IEnumerable<PropertyDetailsEntity>> GetPropertyListByAssetId(string assetId);
    }
}
