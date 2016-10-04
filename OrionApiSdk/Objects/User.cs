using Newtonsoft.Json;
using OrionApiLibrary.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiLibrary.Objects
{

    public class User
    {
        [JsonProperty("entity")]
        public LoginEntity Entity { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty("loginUserId")]
        public string LoginUserId { get; set; }

        [JsonProperty("databaseCount")]
        public int DatabaseCount { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("userDetailId")]
        public int UserDetailId { get; set; }

        [JsonProperty("alClientId")]
        public int AlClientId { get; set; }

        [JsonProperty("alClientName")]
        public string AlClientName { get; set; }

        [JsonProperty("alClientGuid")]
        public string AlClientGuid { get; set; }

        [JsonProperty("instanceName")]
        public string InstanceName { get; set; }

        [JsonProperty("userGuid")]
        public Guid UserGuid { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("twoFactor")]
        public bool TwoFactor { get; set; }

        [JsonProperty("daysUntilPasswordExpires")]
        public int DaysUntilPasswordExpires { get; set; }

        [JsonProperty("entityId")]
        public object EntityId { get; set; }

        [JsonProperty("entityName")]
        public string EntityName { get; set; }

        [JsonProperty("masterGroup")]
        public string MasterGroup { get; set; }
    }

}
