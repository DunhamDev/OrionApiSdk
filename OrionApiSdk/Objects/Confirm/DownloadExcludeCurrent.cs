using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Confirm
{
    public class DownloadExcludeCurrent
    {
        [JsonProperty("downloadNameId")]
        public int DownloadNameId { get; set; }

        [JsonProperty("formatName")]
        public string FormatName { get; set; }

        [JsonProperty("clientName")]
        public string ClientName { get; set; }

        [JsonProperty("fileDate")]
        public DateTime? FileDate { get; set; }

        [JsonProperty("repNumber")]
        public string RepNumber { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("address3")]
        public string Address3 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("downloadFormatId")]
        public int? DownloadFormatId { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("isPriceExclusion")]
        public bool? IsPriceExclusion { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("downloadSourceId")]
        public int DownloadSourceId { get; set; }

        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }

        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
    }
}
