using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class AccountSimple
    {
        [JsonProperty("value")]
        public decimal? Value { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("clientId")]
        public int ClientId { get; set; }

        [JsonProperty("custodian")]
        public string Custodian { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
