using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Trading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Trading
{
    public class ModelsMethods : ApiMethodContainer
    {
        public ModelsMethods(AuthToken token) : base("Trading", "Models", token) { }

        #region Get models
        public List<Model> Get(bool? isUsed = null, bool? excludeSelfDirected = null, bool? canMaintainOnly = null, int? representativeId = null,
            int top = 5000, int skip = 0)
        {
            return GetAsync(isUsed, excludeSelfDirected, canMaintainOnly, representativeId, top, skip).Result;
        }
        public async Task<List<Model>> GetAsync(bool? isUsed = null, bool? excludeSelfDirected = null, bool? canMaintainOnly = null, int? representativeId = null,
            int top = 5000, int skip = 0)
        {
            JToken models = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "isUsed", isUsed },
                { "excludeSelfDirected", excludeSelfDirected },
                { "canMaintainOnly", canMaintainOnly },
                { "representativeId", representativeId },
                { "$skip", skip },
                { "$top", top }
            });
            return models.ToObject<List<Model>>();
        }

        public Model Get(int modelId, bool? includeAccounts = null)
        {
            return GetAsync(modelId, includeAccounts).Result;
        }
        public async Task<Model> GetAsync(int modelId, bool? includeAccounts = null)
        {
            JToken model = await GetJsonAsync(modelId.ToString(), new Dictionary<string, object>
            {
                { "includeAccounts", includeAccounts }
            });
            return model.ToObject<Model>();
        }

        public List<ModelSimple> GetSimple(bool? isUsed = null, bool? excludeSelfDirected = null)
        {
            return GetSimpleAsync(isUsed, excludeSelfDirected).Result;
        }
        public async Task<List<ModelSimple>> GetSimpleAsync(bool? isUsed = null, bool? excludeSelfDirected = null)
        {
            JToken models = await GetJsonAsync("Simple", new Dictionary<string, object>
            {
                { "isUsed", isUsed },
                { "exludeSelfDirected", excludeSelfDirected }
            });
            return models.ToObject<List<ModelSimple>>();
        }
        #endregion

        #region Model value
        public List<Model> GetValues(bool? isUsed = null, bool? resetCache = null, bool? excludeSelfDirected = null, int top = 500, int skip = 0)
        {
            return GetValuesAsync(isUsed, resetCache, excludeSelfDirected, top, skip).Result;
        }
        public async Task<List<Model>> GetValuesAsync(bool? isUsed = null, bool? resetCache = null, bool? excludeSelfDirected = null, int top = 500, int skip = 0)
        {
            JToken modelValues = await GetJsonAsync("Value", new Dictionary<string, object>
            {
                { "isUsed", isUsed },
                { "resetCache", resetCache },
                { "excludeSelfDirected", excludeSelfDirected },
                { "$top", top },
                { "$skip", skip }
            });
            return modelValues.ToObject<List<Model>>();
        }

        public List<Model> GetValues(DateTime asOfDate, bool? isUsed = null, bool? resetCache = null, bool? excludeSelfDirected = null, int top = 500, int skip = 0)
        {
            return GetValuesAsync(asOfDate, isUsed, resetCache, excludeSelfDirected, top, skip).Result;
        }
        public async Task<List<Model>> GetValuesAsync(DateTime asOfDate, bool? isUsed = null, bool? resetCache = null, bool? excludeSelfDirected = null, int top = 500, int skip = 0)
        {
            JToken modelValues = await GetJsonAsync(string.Format("Value/{0:MM-dd-yyyy}", asOfDate), new Dictionary<string, object>
            {
                { "isUsed", isUsed },
                { "resetCache", resetCache },
                { "excludeSelfDirected", excludeSelfDirected },
                { "$top", top },
                { "$skip", skip }
            });
            return modelValues.ToObject<List<Model>>();
        }
        #endregion

        #region Get search
        public List<ModelSimple> GetSimpleSearch(string search, int top = 5000, int skip = 0)
        {
            return GetSimpleSearchAsync(search, top, skip).Result;
        }
        public async Task<List<ModelSimple>> GetSimpleSearchAsync(string search, int top = 5000, int skip = 0)
        {
            JToken models = await GetJsonAsync("Simple/Search", new Dictionary<string, object>
            {
                { "search", search },
                { "$skip", skip },
                { "$top", top }
            });
            return models.ToObject<List<ModelSimple>>();
        }
        #endregion

        public Model PostModel(Model model)
        {
            return PostModelAsync(model).Result;
        }
        public async Task<Model> PostModelAsync(Model model)
        {
            if (HasRequiredData(model))
            {
                var modelResponse = await PostJsonAsync("", "=" + JsonConvert.SerializeObject(model).ToString());
            }
            return model;
        }

        private bool HasRequiredData(Model model)
        {
            return true;
        }
    }
}
