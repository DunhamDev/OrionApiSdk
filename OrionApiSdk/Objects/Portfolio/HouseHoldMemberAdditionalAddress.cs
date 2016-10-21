using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class HouseholdMemberAdditionalAddress
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        
        [JsonProperty("address3")]
        public string Address3 { get; set; }
        
        [JsonProperty("city")]
        public string City { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("zip")]
        public string Zip { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("company")]
        public string Company { get; set; }
        
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
        
        [JsonProperty("webAddress")]
        public string WebAddress { get; set; }
        
        [JsonProperty("sendPeriodicStatements")]
        public bool SendPeriodicStatements { get; set; }
    }
}
