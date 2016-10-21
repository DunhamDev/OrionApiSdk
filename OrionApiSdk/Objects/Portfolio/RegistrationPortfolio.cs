using Newtonsoft.Json;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RegistrationPortfolio : Portfolio
    {
        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("clientId")]
        public int ClientId { get; set; }

        [JsonProperty("dateOfDeath")]
        public DateTime? DateOfDeath { get; set; }

        [JsonProperty("isUsResident")]
        public bool IsUsResident { get; set; }

        [JsonProperty("typeCode")]
        public string TypeCode { get; set; }

        [JsonProperty("typeId")]
        public int TypeId { get; set; }
    }
}
