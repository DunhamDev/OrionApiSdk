using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class ReportImage
    {
        [JsonProperty("image")]
        public byte[] Image { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }

        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("barColor")]
        public string BarColor { get; set; }
    }
}
