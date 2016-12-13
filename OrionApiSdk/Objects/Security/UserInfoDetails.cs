using Newtonsoft.Json;
using OrionApiSdk.Common;
using OrionApiSdk.Common.Converters;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Security
{
    public class UserInfoDetails : BaseUser
    {
        #region Properties
        #region Instance properties
        /// <summary>
        /// The unique user identifier
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Identification used for logging in (effectively a username)
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

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

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("profiles")]
        public List<Profile> Profiles { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        internal IEnumerable<Claim> GetUserClaims()
        {
            List<Claim> claims = new List<Claim>();
            AddGuaranteedClaims(claims);
            AddNullableClaims(claims);
            return claims;
        }

        private void AddGuaranteedClaims(List<Claim> claims)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Id.ToString(), ClaimValueTypes.Integer, OrionConstants.ORION_PROVIDER_NAME));
            claims.Add(new Claim(ClaimTypes.Name, UserId, ClaimValueTypes.String, OrionConstants.ORION_PROVIDER_NAME));
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
            if (!string.IsNullOrWhiteSpace(MobilePhone))
            {
                claims.Add(new Claim(ClaimTypes.MobilePhone, MobilePhone, ClaimValueTypes.String, OrionConstants.ORION_PROVIDER_NAME));
            }
        }
        #endregion
        #endregion
    }
}
