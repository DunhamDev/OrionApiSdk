using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Trading
{
    public class ModelAggEntity
    {
        [JsonProperty("entityId")]
        public int EntityId { get; set; }

        [JsonProperty("entityEnum")]
        public string EntityEnum { get; set; }
    }
}
