using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Trading
{
    public class ModelItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        
        [JsonProperty("productClass")]
        public string ProductClass { get; set; }
        
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        
        [JsonProperty("targetPercent")]
        public decimal TargetPercent { get; set; }
        
        [JsonProperty("itemTol")]
        public int ItemTol { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("itemTolUpper")]
        public decimal ItemTolUpper { get; set; }
        
        [JsonProperty("itemTolLower")]
        public decimal ItemTolLower { get; set; }
        
        [JsonProperty("oub")]
        public decimal? Oub { get; set; }
    }
}
