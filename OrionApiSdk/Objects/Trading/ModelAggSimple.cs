using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;

namespace OrionApiSdk.Objects.Trading
{
    public class ModelAggSimple : BaseSimpleEntity
    {
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
