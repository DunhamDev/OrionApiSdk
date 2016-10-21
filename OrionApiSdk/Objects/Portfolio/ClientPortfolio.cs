using Newtonsoft.Json;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class ClientPortfolio : Portfolio
    {
        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("isQualifiedInvestor")]
        public bool IsQualifiedInvestor { get; set; }

        [JsonProperty("isUsResident")]
        public bool IsUsResident { get; set; }

        [JsonProperty("lastStatementSent")]
        public DateTime? LastStatementSent { get; set; }

        [JsonProperty("lastStatementSentTo")]
        public string LastStatementSentTo { get; set; }

        [JsonProperty("representativeId")]
        public int RepresentativeId { get; set; }

        [JsonProperty("statementDeliveryMethodId")]
        public int StatementDeliveryMethodId { get; set; }

        [JsonProperty("videoStatementDeliveryMethod")]
        public string VideoStatementDeliveryMethod { get; set; }

        [JsonProperty("workPhone")]
        public string WorkPhone { get; set; }

        [JsonProperty("workPhoneExt")]
        public string WorkPhoneExt { get; set; }
    }
}
