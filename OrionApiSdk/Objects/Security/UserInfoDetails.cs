using Newtonsoft.Json;
using OrionApiSdk.Common.Converters;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Security
{
    public class UserInfoDetails : BaseUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("activeDate")]
        public DateTime ActiveDate { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("inactiveDate")]
        public DateTime? InactiveDate { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("lastLogin")]
        public DateTime? LastLogin { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
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

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("profiles")]
        public List<Profile> Profiles { get; set; }
    }
}
