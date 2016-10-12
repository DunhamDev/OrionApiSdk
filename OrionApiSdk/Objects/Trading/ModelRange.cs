using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OrionApiSdk.Objects.Trading
{

    public class ModelRange
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("upperScore")]
        public int UpperScore { get; set; }
        
        [JsonProperty("lowerScore")]
        public int LowerScore { get; set; }
        
        [JsonProperty("userDefinedFields")]
        public List<object> UserDefinedFields { get; set; }
    }
}
