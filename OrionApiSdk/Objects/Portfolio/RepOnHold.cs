using Newtonsoft.Json;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RepOnHold
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("entityEnum")]
        public int EntityEnum { get; set; }
        
        [JsonProperty("holdDate")]
        public DateTime HoldDate { get; set; }
        
        [JsonProperty("holdStatus")]
        public string HoldStatus { get; set; }
    }
}
