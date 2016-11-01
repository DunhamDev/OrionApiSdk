using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Trading
{
    public class ModelAggDetail
    {
        [JsonProperty("modelId")]
        public int ModelId { get; set; }
        
        [JsonProperty("modelName")]
        public string ModelName { get; set; }
        
        [JsonProperty("weightPercent")]
        public decimal WeightPercent { get; set; }
        
        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }
        
        [JsonProperty("managementStyleId")]
        public int? ManagementStyleId { get; set; }
    }

}
