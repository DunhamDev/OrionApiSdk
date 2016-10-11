using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;

namespace OrionApiSdk.Objects.Portfolio
{
    public class AssetSimpleWithValue : BaseSimpleEntity
    {
        [JsonProperty("shares")]
        public decimal Shares { get; set; }
        
        [JsonProperty("price")]
        public decimal Price { get; set; }
        
        [JsonProperty("value")]
        public decimal Value { get; set; }
        
        [JsonProperty("assetClass")]
        public string AssetClass { get; set; }
        
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        
        [JsonProperty("isCustodialCash")]
        public bool IsCustodialCash { get; set; }
        
        [JsonProperty("isTradeExcluded")]
        public bool IsTradeExcluded { get; set; }
    }

}
