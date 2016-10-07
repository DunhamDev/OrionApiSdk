using Newtonsoft.Json;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Note
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }

        [JsonProperty("editedDate")]
        public DateTime? EditedDate { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("isWebVisible")]
        public bool IsWebVisible { get; set; }

        [JsonProperty("isSystemGenerated")]
        public bool IsSystemGenerated { get; set; }
    }
}
