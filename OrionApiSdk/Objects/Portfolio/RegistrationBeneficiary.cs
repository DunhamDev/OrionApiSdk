using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RegistrationBeneficiary : BaseSimpleEntity
    {
        [JsonProperty("dob")]
        public DateTime? DoB { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("relation")]
        public string Relation { get; set; }

        [JsonProperty("percentage")]
        public decimal Percentage { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("ssn")]
        public string SSN { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
