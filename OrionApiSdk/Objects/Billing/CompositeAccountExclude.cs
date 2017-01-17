using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Billing
{
    public class CompositeAccountExclude
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }

        [JsonProperty("editedBy")]
        public DateTime EditedBy { get; set; }
    }
}
