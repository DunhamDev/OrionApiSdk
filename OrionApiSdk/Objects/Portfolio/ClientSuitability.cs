using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class ClientSuitability
    {
        [JsonProperty("returnObjective")]
        public string ReturnObjective { get; set; }
        
        [JsonProperty("investmentObjective")]
        public string InvestmentObjective { get; set; }
        
        [JsonProperty("timeHorizon")]
        public string TimeHorizon { get; set; }
        
        [JsonProperty("stockPercent")]
        public string StockPercent { get; set; }
        
        [JsonProperty("riskTolerance")]
        public int RiskTolerance { get; set; }
    }
}
