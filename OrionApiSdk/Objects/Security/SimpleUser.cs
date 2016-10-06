using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Security
{
    public class SimpleUser : BaseUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("activeDate")]
        public DateTime ActiveDate { get; set; }

        [JsonProperty("inactiveDate")]
        public DateTime? InactiveDate { get; set; }

        [JsonProperty("lastLogin")]
        public DateTime? LastLogin { get; set; }

        [JsonProperty("lastPasswordChange")]
        public DateTime? LastPasswordChange { get; set; }

        [JsonProperty("isReset")]
        public bool IsReset { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("businessPhone")]
        public string BusinessPhone { get; set; }

        [JsonProperty("businessPhoneExtension")]
        public string BusinessPhoneExtension { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
    }
}
