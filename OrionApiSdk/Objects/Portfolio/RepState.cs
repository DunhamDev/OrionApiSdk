using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RepState
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("stateId")]
        public int StateId { get; set; }
        
        [JsonProperty("stateName")]
        public string StateName { get; set; }
    }
}
