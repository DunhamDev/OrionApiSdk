using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Owin.Providers.Orion
{
    public class OrionAuthenticationOptions : AuthenticationOptions
    {
        #region Instance properties
        public PathString CallbackPath { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string SignInAsAutenticationType { get; set; }

        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
        #endregion

        public OrionAuthenticationOptions(string clientId, string clientSecret) : base("Orion")
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            CallbackPath = new PathString("/signin-orion");
            Description.Caption = "Orion";
            AuthenticationMode = AuthenticationMode.Passive;
        }
    }
}
