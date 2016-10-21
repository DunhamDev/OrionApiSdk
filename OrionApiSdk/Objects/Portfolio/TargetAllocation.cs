using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class TargetAllocation
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("entity")]
        public string Entity { get; set; }
        
        [JsonProperty("entityId")]
        public int EntityId { get; set; }
        
        [JsonProperty("weight")]
        public decimal Weight { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime? EditedDate { get; set; }
    }
}
