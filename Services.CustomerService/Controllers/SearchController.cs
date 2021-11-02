using Microsoft.AspNetCore.Mvc;
using Services.CustomerService.Services.Interfaces;
using Services.CustomerService.ViewModel;
using System.Threading.Tasks;

namespace Services.CustomerService.Controllers
{
    /// <summary>
    /// This controller used for search like auto search, global and advance search.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        /// <summary>
        /// The search service
        /// </summary>
        private readonly ISearchService _ISearchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController" /> class.
        /// </summary>
        /// <param name="searchService">The search service.</param>
        public SearchController(ISearchService searchService)
        {
            _ISearchService = searchService;
        }

        /// <summary>
        /// Finds the specified query.
        /// </summary>
        /// <param name="searchText">The query.</param>
        /// <param name="stateList">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/global/autosearch/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> Search(string searchText, string stateList)
        {
            var result = await _ISearchService.GetList(searchText, stateList);
            return Ok(result);
        }

        /// <summary>
        /// This service used to get advance asset list when user choose value from auto suggestion pop-up.
        /// </summary>
        /// <param name="parcelId">The parcel identifier.</param>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/global/search/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> SearchByParcelIdAndAssetId(string parcelId, string assetId)
        {
            var result = await _ISearchService.GetListByParcelIdAndAssetId(parcelId, assetId);
            return Ok(result);
        }

        /// <summary>
        /// This service used to get advance asset list when search on search box.
        /// </summary>
        /// <param name="searchText">The search value.</param>
        /// <param name="stateList">The state list.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/advanced/search/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> AdvancedSearch(string searchText, string stateList)
        {
            var result = await _ISearchService.GetListBySearchTextAndState(searchText, stateList);
            return Ok(result);
        }

        /// <summary>
        /// This service used to get advance asset list when advance filter applied.
        /// </summary>
        /// <param name="searchOptions">The global search option input advanced entity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/advanced/search/post")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> AdvancedSearchWithFilters([FromBody]GlobalSearchOptionInputAdvancedEntity searchOptions)
        {
            var result = await _ISearchService.GetListByFilters(searchOptions);
            return Ok(result);
        }
    }
}
