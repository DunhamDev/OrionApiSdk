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
    }
}
