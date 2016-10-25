using OrionApiSdk.Objects.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Common.Extensions
{
    public static class ClaimsIdentityExtensions
    {
        private const string W3_CLAIM_STRING_TYPE = "http://www.w3.org/2001/XMLSchema#string";

        public static void BuildIdentityFromOrionProfile(this ClaimsIdentity identity, string oauthProvider, UserDetails orionProfile)
        {
            #region Guaranteed fields
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, orionProfile.UserId, W3_CLAIM_STRING_TYPE, oauthProvider));
            identity.AddClaim(new Claim(ClaimTypes.Name, orionProfile.LoginUserId, W3_CLAIM_STRING_TYPE, oauthProvider));
            #endregion

            #region Nullable fields
            if (!string.IsNullOrWhiteSpace(orionProfile.FirstName))
            {
                identity.AddClaim(new Claim(ClaimTypes.GivenName, orionProfile.FirstName, W3_CLAIM_STRING_TYPE, oauthProvider));
            }
            if (!string.IsNullOrWhiteSpace(orionProfile.LastName))
            {
                identity.AddClaim(new Claim(ClaimTypes.Surname, orionProfile.LastName, W3_CLAIM_STRING_TYPE, oauthProvider));
            }
            if (!string.IsNullOrWhiteSpace(orionProfile.Email))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, orionProfile.Email, W3_CLAIM_STRING_TYPE, oauthProvider));
            }
            if (!string.IsNullOrEmpty(orionProfile.MobilePhone))
            {
                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, orionProfile.MobilePhone, W3_CLAIM_STRING_TYPE, oauthProvider));
            }
            #endregion
        }
    }
}
