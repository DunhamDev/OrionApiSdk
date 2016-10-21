using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BillRecurrentAdjustment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("annualAmount")]
        public decimal AnnualAmount { get; set; }
        
        [JsonProperty("type")]
        public int Type { get; set; }
        
        [JsonProperty("schedule")]
        public int Schedule { get; set; }
        
        [JsonProperty("adjustmentType")]
        public int AdjustmentType { get; set; }
        
        [JsonProperty("responsibleEntity")]
        public int ResponsibleEntity { get; set; }
    }
}
