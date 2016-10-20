using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Trading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Trading
{
    public class ModelAggsMethods : ApiMethodContainer
    {
        public ModelAggsMethods(AuthToken token) : base("Trading", "ModelAggs", token) { }

        #region Get model aggs
        public List<ModelAgg> Get(int? accountId = null, int? subAdvisorId = null, int? registrationId = null, bool? excludeSelfDirected = null,
            string modelType = null, string modelAggType = null, bool? canMaintainOnly = null, bool? withOrders = null, bool? forUser = null,
            int? representativeId = null, int top = 5000, int skip = 0)
        {
            return GetAsync(accountId, subAdvisorId, registrationId, excludeSelfDirected, modelType, modelAggType, canMaintainOnly, withOrders,
                forUser, representativeId, top, skip).Result;
        }
        public async Task<List<ModelAgg>> GetAsync(int? accountId = null, int? subAdvisorId = null, int? registrationId = null, bool? excludeSelfDirected = null,
            string modelType = null, string modelAggType = null, bool? canMaintainOnly = null, bool? withOrders = null, bool? forUser = null,
            int? representativeId = null, int top = 5000, int skip = 0)
        {
            JToken modelAggregates = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "accountId", accountId },
                { "subAdvisorId", subAdvisorId },
                { "registrationId", registrationId },
                { "excludeSelfDirected", excludeSelfDirected },
                { "modelType", modelType },
                { "modelAggType", modelAggType },
                { "canMaintainOnly", canMaintainOnly },
                { "withOrders", withOrders },
                { "forUser", forUser },
                { "representativeId", representativeId },
                { "$top", top },
                { "$skip", skip },
            });
            return modelAggregates.ToObject<List<ModelAgg>>();
        }

        public ModelAgg Get(int modelAggId)
        {
            return GetAsync(modelAggId).Result;
        }
        public async Task<ModelAgg> GetAsync(int modelAggId)
        {
            JToken modelAgg = await GetJsonAsync(modelAggId.ToString());
            return modelAgg.ToObject<ModelAgg>();
        }

        public List<ModelAggSimple> GetSimple(bool? isUsed = null, bool? excludeSelfDirected = null, bool? withOrders = null)
        {
            return GetSimpleAsync(isUsed, excludeSelfDirected, withOrders).Result;
        }
        public async Task<List<ModelAggSimple>> GetSimpleAsync(bool? isUsed = null, bool? excludeSelfDirected = null, bool? withOrders = null)
        {
            JToken simpleAggs = await GetJsonAsync("Simple", new Dictionary<string, object>
            {
                { "isUsed", isUsed },
                { "excludeSelfDirected", excludeSelfDirected },
                { "withOrders", withOrders },
            });
            return simpleAggs.ToObject<List<ModelAggSimple>>();
        }
        #endregion

        public List<Objects.Portfolio.Account> GetAccounts(int modelAggId, bool? isActive = null, bool? isManaged = null, int top = 5000, int skip = 0)
        {
            return GetAccountsAsync(modelAggId, isActive, isManaged, top, skip).Result;
        }
        public async Task<List<Objects.Portfolio.Account>> GetAccountsAsync(int modelAggId, bool? isActive = null, bool? isManaged = null, int top = 5000, int skip = 0)
        {
            var accountsJson = await GetJsonAsync(string.Format("{0}/Accounts", modelAggId), new Dictionary<string, object>
            {
                { "isActive", isActive },
                { "isManaged", isManaged },
                { "$top", top },
                { "$skip", skip },
            });

            return accountsJson.ToObject<List<Objects.Portfolio.Account>>();
        }

        #region Allocations
        public List<ModelItem> GetAllocations(int modelAggId)
        {
            return GetAllocationsAsync(modelAggId).Result;
        }
        public async Task<List<ModelItem>> GetAllocationsAsync(int modelAggId)
        {
            var allocationsJson = await GetJsonAsync(string.Format("{0}/Allocations", modelAggId));
            return allocationsJson.ToObject<List<ModelItem>>();
        }

        public List<ModelItem> GetAccountAllocations(int modelAggId, int accountId)
        {
            return GetAccountAllocationsAsync(modelAggId, accountId).Result;
        }
        public async Task<List<ModelItem>> GetAccountAllocationsAsync(int modelAggId, int accountId)
        {
            var allocationsJson = await GetJsonAsync(string.Format("{0}/{1}/Allocations", modelAggId, accountId));
            return allocationsJson.ToObject<List<ModelItem>>();
        }
        #endregion

        public List<string> GetAggTypes()
        {
            return GetAggTypesAsync().Result;
        }
        public async Task<List<string>> GetAggTypesAsync()
        {
            var aggTypesJson = await GetJsonAsync("AggTypes");
            return aggTypesJson.ToObject<List<string>>();
        }

        public List<ModelAggSimple> GetSimpleSearch(string search, int top = 5000, int skip = 0, bool? activeOnly = null)
        {
            return GetSimpleSearchAsync(search, top, skip, activeOnly).Result;
        }
        public async Task<List<ModelAggSimple>> GetSimpleSearchAsync(string search, int top = 5000, int skip = 0, bool? activeOnly = null)
        {
            var modelAggsJson = await GetJsonAsync("Search", new Dictionary<string, object>
            {
                { "search", search },
                { "top", top },
                { "skip", skip },
                { "activeOnly", activeOnly },
            });
            return modelAggsJson.ToObject<List<ModelAggSimple>>();
        }

        /// <summary>
        /// HTTP POST: /Trading/ModelAggs
        /// Creates a model aggreagtion. Use <see cref="ModelAgg.CheckForMinimumDataForCreate"/> to verify
        /// the minimum data points needed for creation are populated
        /// </summary>
        /// <param name="modelAggToCreate">The model aggreation to create</param>
        /// <returns>The newly created model aggregation</returns>
        public ModelAgg Create(ModelAgg modelAggToCreate)
        {
            try
            {
                return CreateAsync(modelAggToCreate).Result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
        /// <summary>
        /// HTTP POST: /Trading/ModelAggs
        /// Creates a model aggreagtion. Use <see cref="ModelAgg.CheckForMinimumDataForCreate"/> to verify
        /// the minimum data points needed for creation are populated
        /// </summary>
        /// <param name="modelAggToCreate">The model aggreation to create</param>
        /// <returns>The newly created model aggregation</returns>
        public async Task<ModelAgg> CreateAsync(ModelAgg modelAggToCreate)
        {
            if (modelAggToCreate == null)
            {
                throw new ArgumentNullException("modelAggToCreate");
            }

            modelAggToCreate.CheckForMinimumDataForCreate();
            var modelAggResponse = await PostJsonAsync("", modelAggToCreate);
            return modelAggResponse.ToObject<ModelAgg>();
        }
    }
}
