using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RepNasd
    {
        [JsonProperty("nasdId")]
        public int NasdId { get; set; }
        
        [JsonProperty("representativeId")]
        public int RepresentativeId { get; set; }
        
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
