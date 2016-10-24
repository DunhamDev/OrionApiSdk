using OrionApiSdk.Objects.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Common.ExtensionMethods
{
    public static class ClaimsIdentityExtensions
    {
        private const string W3_CLAIM_STRING_TYPE = "http://www.w3.org/2001/XMLSchema#string";

        public static void BuildIdentityFromOrionProfile(this ClaimsIdentity identity, string oauthProvider, UserProfile orionProfile)
        {
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, orionProfile.UserId, W3_CLAIM_STRING_TYPE, oauthProvider));
            if (!string.IsNullOrWhiteSpace(orionProfile.LastName))
            {
                identity.AddClaim(new Claim(ClaimTypes.Surname, orionProfile.LastName, W3_CLAIM_STRING_TYPE, oauthProvider));
            }
            if (!string.IsNullOrWhiteSpace(orionProfile.Email))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, orionProfile.Email, W3_CLAIM_STRING_TYPE, oauthProvider));
            }
            identity.AddClaim(new Claim(ClaimTypes.Name, orionProfile.LoginUserId));
        }
    }
}
