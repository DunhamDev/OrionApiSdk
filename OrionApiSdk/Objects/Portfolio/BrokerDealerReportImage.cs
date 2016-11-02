using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BrokerDealerReportImage : ReportImage
    {
        [JsonProperty("brokerDealerId")]
        public int BrokerDealerId { get; set; }
    }
}