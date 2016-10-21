using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BillRelatedClient
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("billClientId")]
        public int BillClientId { get; set; }

        [JsonProperty("clientId")]
        public int ClientId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
