using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Trading;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Trading
{
    public class ModelAggsMethods : ApiMethodContainer<ModelAgg>
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
            JToken modelAggregates = await GetJsonAsync("", new NameValueCollection
            {
                { "accountId", accountId.ToString() },
                { "subAdvisorId", subAdvisorId.ToString() },
                { "registrationId", registrationId.ToString() },
                { "excludeSelfDirected", excludeSelfDirected.ToString() },
                { "modelType", modelType },
                { "modelAggType", modelAggType },
                { "canMaintainOnly", canMaintainOnly.ToString() },
                { "withOrders", withOrders.ToString() },
                { "forUser", forUser.ToString() },
                { "representativeId", representativeId.ToString() },
                { "$top", top.ToString() },
                { "$skip", skip.ToString() },
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
            JToken simpleAggs = await GetJsonAsync("Simple", new NameValueCollection
            {
                { "isUsed", isUsed.ToString() },
                { "excludeSelfDirected", excludeSelfDirected.ToString() },
                { "withOrders", withOrders.ToString() },
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
            var accountsJson = await GetJsonAsync(string.Format("{0}/Accounts", modelAggId), new NameValueCollection
            {
                { "isActive", isActive.ToString() },
                { "isManaged", isManaged.ToString() },
                { "$top", top.ToString() },
                { "$skip", skip.ToString() },
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
            var modelAggsJson = await GetJsonAsync("Search", new NameValueCollection
            {
                { "search", search },
                { "top", top.ToString() },
                { "skip", skip.ToString() },
                { "activeOnly", activeOnly.ToString() },
            });
            return modelAggsJson.ToObject<List<ModelAggSimple>>();
        }

        #region Overrides
        /// <summary>
        /// HTTP POST: /Trading/ModelAggs
        /// Creates a model aggreagtion. Use <see cref="ModelAgg.CheckNecessaryDataForCreate"/> to verify
        /// the minimum data points needed for creation are populated
        /// </summary>
        /// <param name="modelAggToCreate">The model aggreation to create</param>
        /// <returns>The newly created model aggregation</returns>
        public override ModelAgg Create(ModelAgg modelAggToCreate)
        {
            return base.Create(modelAggToCreate);
        }
        /// <summary>
        /// HTTP POST: /Trading/ModelAggs
        /// Creates a model aggreagtion. Use <see cref="ModelAgg.CheckNecessaryDataForCreate"/> to verify
        /// the minimum data points needed for creation are populated
        /// </summary>
        /// <param name="modelAggToCreate">The model aggreation to create</param>
        /// <returns>The newly created model aggregation</returns>
        public override async Task<ModelAgg> CreateAsync(ModelAgg modelAggToCreate)
        {
            return await base.CreateAsync(modelAggToCreate);
        }

        /// <summary>
        /// HTTP PUT: /Trading/ModelAggs/{modelAggId}
        /// Updates the given model aggreation. Use <see cref="ModelAgg.CheckNecessaryDataForUpdate"/> 
        /// to verify the necessary data points have been filled
        /// </summary>
        /// <param name="modelAggToUpdate">The model aggregation to update</param>
        /// <returns>The newly updated model aggregation</returns>
        public override ModelAgg Update(ModelAgg modelAggToUpdate)
        {
            return base.Update(modelAggToUpdate);
        }
        /// <summary>
        /// HTTP PUT: /Trading/ModelAggs/{modelAggId}
        /// Updates the given model aggreation. Use <see cref="ModelAgg.CheckNecessaryDataForUpdate"/> 
        /// to verify the necessary data points have been filled
        /// </summary>
        /// <param name="modelAggToUpdate">The model aggregation to update</param>
        /// <returns>The newly updated model aggregation</returns>
        public override async Task<ModelAgg> UpdateAsync(ModelAgg modelAggToUpdate)
        {
            return await base.UpdateAsync(modelAggToUpdate);
        }
        #endregion
    }
}
