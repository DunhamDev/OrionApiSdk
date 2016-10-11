using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BrokerDealerSimple : BaseSimpleEntity
    {
        [JsonProperty("value")]
        public decimal? Value { get; set; }
    }
}
