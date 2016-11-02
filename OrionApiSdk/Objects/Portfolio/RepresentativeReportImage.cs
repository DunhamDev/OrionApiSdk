using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RepresentativeReportImage : ReportImage
    {
        [JsonProperty("representativeId")]
        public int RepresentativeId { get; set; }
    }
}
