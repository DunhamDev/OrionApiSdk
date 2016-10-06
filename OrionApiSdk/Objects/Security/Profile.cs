using Newtonsoft.Json;
using OrionApiSdk.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Security
{
    public class Profile
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("loginEntityId")]
        public int LoginEntityId { get; set; }

        [JsonProperty("entity")]
        public LoginEntity LoginEntity { get; set; }

        [JsonProperty("entityId")]
        public int EntityId { get; set; }

        [JsonProperty("advisorName")]
        public string AdvisorName { get; set; }

        [JsonProperty("entityName")]
        public string EntityName { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("isUserDefault")]
        public bool IsUserDefault { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("isInCurrentDb")]
        public bool IsInCurrentDb { get; set; }
    }
}
