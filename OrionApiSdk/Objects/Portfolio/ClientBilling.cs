using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class ClientBilling
    {
        [JsonProperty("billClientId")]
        public int BillClientId { get; set; }

        [JsonProperty("statusType")]
        public string StatusType { get; set; }

        [JsonProperty("relatedClient")]
        public BillRelatedClient RelatedClient { get; set; }
    }
}
