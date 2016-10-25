using Microsoft.Owin;
using Microsoft.Owin.Security;
using OrionApiSdk.Common;

namespace OrionApiSdk.Owin.Providers.Orion
{
    public class OrionAuthenticationOptions : AuthenticationOptions
    {
        #region Instance properties
        public PathString CallbackPath { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string SignInAsAutenticationType { get; set; }

        public bool UseTestApiEndpoint { get; set; }

        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
        #endregion

        public OrionAuthenticationOptions(string clientId, string clientSecret, bool useTestApiEndpoint = false) : base("Orion")
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            CallbackPath = new PathString("/signin-orion");
            UseTestApiEndpoint = useTestApiEndpoint;
            Description.Caption = OrionConstants.ORION_PROVIDER_NAME;
            AuthenticationMode = AuthenticationMode.Passive;
        }
    }
}
