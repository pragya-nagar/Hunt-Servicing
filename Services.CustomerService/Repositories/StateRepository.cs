using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Services.CustomerService.Repositories.Constants;
using Services.CustomerService.Repositories.Interfaces;
using Services.CustomerService.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Services.Common.Constants;

namespace Services.CustomerService.Repositories
{
    /// <summary>
    /// StateRepository
    /// </summary>
    public class StateRepository : IStateRepository
    {
        private readonly ILogger _logger;
        /// <summary>
        /// _conn
        /// </summary>
        public string _conn { get; set; }

        /// <summary>
        /// StateRepository
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public StateRepository(ILogger<StateRepository> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._conn = configuration.GetConnectionString(AppSettingConstants.ConnName);
        }
        /// <summary>
        /// GetStateList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StateListEntity>> GetStateList()
        {
            try
            {
                this._logger.LogInformation("GetStateList() triggered to get State data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    IEnumerable<StateListEntity> stateListEntities = null;
                    var sql = CustomerServiceQueries.GetStates;
                    if (_conn != null)
                        stateListEntities = await connection.QueryAsync<StateListEntity>(sql);
                    return stateListEntities;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetStateList() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetGlobalSearchOptionList
        /// </summary>
        /// <param name="filterValue"></param>
        /// <param name="stateList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GlobalSearchOptionEntity>> GetGlobalSearchOptionList(string filterValue, string stateList)
        {
            try
            {
                this._logger.LogInformation("GetGlobalSearchOptionList() triggered to get global search data by filter value and input state list");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = CustomerServiceQueries.GetGlobalSearchSP;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_filter", !string.IsNullOrWhiteSpace(filterValue) ? filterValue : "");
                    parameters.Add("@v_statelist", (string.IsNullOrWhiteSpace(stateList) || stateList == "0") ? null : stateList);
                    IEnumerable<GlobalSearchOptionEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<GlobalSearchOptionEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetGlobalSearchOptionList() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetAssetStatusList
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AssetStatusEntity>> GetAssetStatusList()
        {
            try
            {
                this._logger.LogInformation("GetAssetStatusList() triggered to get asset status data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sql = CustomerServiceQueries.QueryAssetStatus;
                    IEnumerable<AssetStatusEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<AssetStatusEntity>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetAssetStatusList() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetGlobalPopUpSearchOptionListByParcelId
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="searchValue"></param>
        /// <param name="stateList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchOptionListByParcelId(string parcelId, string searchValue, string stateList)
        {
            try
            {
                this._logger.LogInformation("GetGlobalPopUpSearchOptionListByParcelId() triggered to get global popUp search result data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var inputSearchValue = !string.IsNullOrWhiteSpace(searchValue) ? searchValue : "";
                    var sp = CustomerServiceQueries.GetGlobalPopUpSearchResultByParcelId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_ParcelId", !string.IsNullOrWhiteSpace(parcelId) ? parcelId : "");
                    parameters.Add("@v_Search", !string.IsNullOrWhiteSpace(parcelId) ? "" : inputSearchValue);
                    parameters.Add("@v_statelist", !string.IsNullOrWhiteSpace(stateList) ? stateList : "");
                    IEnumerable<SearchGridResponseEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<SearchGridResponseEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetGlobalPopUpSearchOptionListByParcelId() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetGlobalPopUpSearchResultByParcelIdAndAssetId
        /// </summary>
        /// <param name="parcelId"></param>
        /// <param name="assetId"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchGridResponseEntity>> GetGlobalPopUpSearchResultByParcelIdAndAssetId(string parcelId, string assetId, string searchValue)
        {
            try
            {
                this._logger.LogInformation("GetGlobalPopUpSearchResultByParcelIdAndAssetId() triggered to get global popUp search result data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var inputSearchValue = !string.IsNullOrWhiteSpace(searchValue) ? searchValue : "";
                    var sp = CustomerServiceQueries.GetGlobalPopUpSearchResultByParcelIdAndAssetId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_ParcelId", !string.IsNullOrWhiteSpace(parcelId) ? parcelId : "");
                    parameters.Add("@v_AssetId", !string.IsNullOrWhiteSpace(parcelId) ? assetId : "");
                    parameters.Add("@v_Search", !string.IsNullOrWhiteSpace(parcelId) ? "" : inputSearchValue);
                    IEnumerable<SearchGridResponseEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<SearchGridResponseEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetGlobalPopUpSearchResultByParcelIdAndAssetId() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetGlobalSearchOptionListAdvanced
        /// </summary>
        /// <param name="globalSearchOptionEntity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchGridResponseEntity>> GetGlobalSearchOptionListAdvanced(GlobalSearchOptionInputAdvancedEntity globalSearchOptionEntity)
        {
            try
            {
                this._logger.LogInformation("GetGlobalSearchOptionListAdvanced() triggered to get advanced global search data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = CustomerServiceQueries.GetGlobalSearchSPAdvanced;
                    var parameters = new DynamicParameters();

                    parameters.Add("@v_AssetId", globalSearchOptionEntity?.AssetId ?? string.Empty);
                    parameters.Add("@v_OriAssetId", globalSearchOptionEntity?.OriAssetId ?? string.Empty);
                    parameters.Add("@v_AlternativeId", globalSearchOptionEntity?.AlternativeId ?? string.Empty);
                    parameters.Add("@v_StateId", globalSearchOptionEntity?.StateId ?? 0);
                    parameters.Add("@v_Jurisdiction", globalSearchOptionEntity?.Jurisdication ?? string.Empty);
                    parameters.Add("@v_AssetStatus", globalSearchOptionEntity?.AssetStatusId ?? 0);
                    parameters.Add("@v_LienHierarchy", globalSearchOptionEntity?.LienHieraechy ?? string.Empty);
                    parameters.Add("@v_AcquisitionDate", globalSearchOptionEntity?.AcquisationDate ?? string.Empty);
                    parameters.Add("@v_OwnerName", globalSearchOptionEntity?.OwnerName ?? string.Empty);
                    parameters.Add("@v_OwnerAddress", globalSearchOptionEntity?.OwnerAddress ?? string.Empty);
                    parameters.Add("@v_PropertyAddress", globalSearchOptionEntity?.PropertyAddress ?? string.Empty);
                    parameters.Add("@v_ParcelId", globalSearchOptionEntity?.ParcelID ?? string.Empty);
                    parameters.Add("@v_AlternateParcelId1", globalSearchOptionEntity?.AlternativeParcelID1 ?? string.Empty);
                    parameters.Add("@v_AlternateParcelId2", globalSearchOptionEntity?.AlternativeParcelID2 ?? string.Empty);
                    parameters.Add("@v_AlternateParcelId3", globalSearchOptionEntity?.AlternativeParcelID3 ?? string.Empty);
                    parameters.Add("@v_CertNo", globalSearchOptionEntity?.CertNo ?? string.Empty);
                    parameters.Add("@v_PurchasingEntity", globalSearchOptionEntity?.PurchasingEntity ?? string.Empty);
                    parameters.Add("@v_CurrentEntity", globalSearchOptionEntity?.CurrentEntity ?? string.Empty);
                    parameters.Add("@v_FinancingGroup", globalSearchOptionEntity?.FinancialGroup ?? string.Empty);
                    parameters.Add("@v_AttorneyName", globalSearchOptionEntity?.AttorneyName ?? string.Empty);
                    parameters.Add("@v_ContactPerson", globalSearchOptionEntity?.ContactName ?? string.Empty);
                    parameters.Add("@v_CellPhone", globalSearchOptionEntity?.ContactPhone ?? string.Empty);

                    IEnumerable<SearchGridResponseEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<SearchGridResponseEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetGlobalSearchOptionListAdvanced() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetLienHeaderInfoByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<LienHeaderInfoEntity> GetLienHeaderInfoByAssetId(string assetId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    this._logger.LogInformation("ExtractLienInfoFromLienModel() triggered to get lien header info data");
                    var sql = CustomerServiceQueries.GetLienHeaderInfoQuery;
                    if (_conn != null)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@assetId", assetId);
                        var result = await connection.QueryAsync<LienHeaderInfoEntityResponse>(sql, parameters);
                        var response = result.ToList();
                        return new LienHeaderInfoEntity()
                        {
                            AssetId = response.Select(i => i.AssetId).Distinct().FirstOrDefault(),
                            PropertyTypeName = response.Select(i => i.PropertyTypeName).Distinct().FirstOrDefault(),
                            AssetName = response.Select(i => i.AssetName).Distinct(),
                            PropertyAddress = response.Select(i => i.PropertyAddress).Distinct()
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing ExtractLienInfoFromLienModel() in StateRepository with Message" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// GetLienAssetInfoByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LienAssetInfoEntity>> GetLienAssetInfoByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetLienAssetInfoByAssetId() triggered to get lien asset info data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = CustomerServiceQueries.GetLienAssetInfo;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_AssetId", assetId);
                    IEnumerable<LienAssetInfoEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<LienAssetInfoEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetLienAssetInfoByAssetId() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetLienRecentActivityByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="v_HasLimit"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LienRecentActivityEntity>> GetLienRecentActivityByAssetId(string assetId, bool v_HasLimit = false)
        {
            try
            {
                this._logger.LogInformation("GetLienRecentActivityByAssetId() triggered to get lien recent activity data limit");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = CustomerServiceQueries.GetLienRecentActivityInfo;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_AssetId", assetId);
                    parameters.Add("@v_HasLimit", v_HasLimit);
                    IEnumerable<LienRecentActivityEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<LienRecentActivityEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetLienRecentActivityByAssetId() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetEventTypeByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventTypeEntity>> GetEventTypeByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetEventTypeByAssetId() triggered to get event type data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = CustomerServiceQueries.GetEventTypeByAssetId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_AssetId", assetId);
                    IEnumerable<EventTypeEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<EventTypeEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetEventTypeByAssetId() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetFlagActionByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FlagActionEntity>> GetFlagActionByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetFlagActionByAssetId() triggered to get flag action data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = CustomerServiceQueries.GetFlagActionByAssetId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_AssetId", assetId);
                    IEnumerable<FlagActionEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<FlagActionEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetFlagActionByAssetId() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
        /// <summary>
        /// GetOtherActionByAssetId
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FlagActionEntity>> GetOtherActionByAssetId(string assetId)
        {
            try
            {
                this._logger.LogInformation("GetOtherActionByAssetId() triggered to get other flag action data");
                using (var connection = new NpgsqlConnection(this._conn))
                {
                    var sp = CustomerServiceQueries.GetOtherActionByAssetId;
                    var parameters = new DynamicParameters();
                    parameters.Add("@v_AssetId", assetId);
                    IEnumerable<FlagActionEntity> result = null;
                    if (_conn != null)
                        result = await connection.QueryAsync<FlagActionEntity>(sp, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Run time error while executing GetOtherActionByAssetId() in StateRepository with Message" + ex.Message);
                throw;
            }
        }
    }
}
