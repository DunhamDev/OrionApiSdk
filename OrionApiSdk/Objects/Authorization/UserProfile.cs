﻿using Newtonsoft.Json;
using OrionApiSdk.Common;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Authorization
{

    public class UserProfile : BaseUser
    {
        /// <summary>
        /// The unique identifier for the user
        /// </summary>
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("entity")]
        public Entity Entity { get; set; }

        /// <summary>
        /// Unknown use at this time, use <see cref="LoginUserId"/>
        /// </summary>
        [JsonProperty("userName")]
        public string Username { get; set; }

        /// <summary>
        /// Identification used for logging in (effectively a username)
        /// </summary>
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

        /// <summary>
        /// Determines whether the user has Two-Factor authentication enabled
        /// </summary>
        [JsonProperty("twoFactor")]
        public bool TwoFactor { get; set; }

        [JsonProperty("daysUntilPasswordExpires")]
        public int DaysUntilPasswordExpires { get; set; }

        [JsonProperty("entityId")]
        public object EntityId { get; set; }

        [JsonProperty("masterGroup")]
        public string MasterGroup { get; set; }

        /// <summary>
        /// User's mobile phone number
        /// </summary>
        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// User's business phone number
        /// </summary>
        [JsonProperty("businessPhone")]
        public string BusinessPhone { get; set; }

        /// <summary>
        /// User's business phone extension
        /// </summary>
        [JsonProperty("businessPhoneExtension")]
        public string BusinessPhoneExtension { get; set; }

        /// <summary>
        /// Contactenates the <see cref="BusinessPhone"/> and <see cref="BusinessPhoneExtension"/>
        /// properties, as appropriate
        /// </summary>
        public string FullBusinessPhone
        {
            get
            {
                string phoneNum = BusinessPhone;
                if (!string.IsNullOrWhiteSpace(BusinessPhoneExtension) &&
                    !string.IsNullOrWhiteSpace(phoneNum))
                {
                    phoneNum += BusinessPhoneExtension;
                }
                return phoneNum;
            }
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            List<Claim> claims = new List<Claim>();
            AddGuaranteedClaims(claims);
            AddNullableClaims(claims);
            return claims;
        }
        private void AddGuaranteedClaims(List<Claim> claims)
        {
            claims.Add(new Claim(ClaimTypes.Name, LoginUserId, ClaimValueTypes.String, OrionConstants.ORION_PROVIDER_NAME));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, UserId.ToString(), ClaimValueTypes.Integer, OrionConstants.ORION_PROVIDER_NAME));
        }
        private void AddNullableClaims(List<Claim> claims)
        {
            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                claims.Add(new Claim(ClaimTypes.GivenName, FirstName, ClaimValueTypes.String, OrionConstants.ORION_PROVIDER_NAME));
            }
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                claims.Add(new Claim(ClaimTypes.Surname, LastName, ClaimValueTypes.String, OrionConstants.ORION_PROVIDER_NAME));
            }
            if (!string.IsNullOrWhiteSpace(Email))
            {
                claims.Add(new Claim(ClaimTypes.Email, Email, ClaimValueTypes.String, OrionConstants.ORION_PROVIDER_NAME));
            }
        }
    }
}
