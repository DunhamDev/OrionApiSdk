﻿using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Authorization
{

    public class UserProfile : BaseUser
    {
        [JsonProperty("entity")]
        public LoginEntity Entity { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty("loginUserId")]
        public string LoginUserId { get; set; }

        [JsonProperty("databaseCount")]
        public int DatabaseCount { get; set; }

        [JsonProperty("userDetailId")]
        public int UserDetailId { get; set; }

        [JsonProperty("alClientId")]
        public int AlClientId { get; set; }

        [JsonProperty("alClientName")]
        public string AlClientName { get; set; }

        [JsonProperty("alClientGuid")]
        public Guid AlClientGuid { get; set; }

        [JsonProperty("instanceName")]
        public string InstanceName { get; set; }

        [JsonProperty("userGuid")]
        public Guid UserGuid { get; set; }

        [JsonProperty("twoFactor")]
        public bool TwoFactor { get; set; }

        [JsonProperty("daysUntilPasswordExpires")]
        public int DaysUntilPasswordExpires { get; set; }

        [JsonProperty("entityId")]
        public object EntityId { get; set; }

        [JsonProperty("masterGroup")]
        public string MasterGroup { get; set; }
    }

}