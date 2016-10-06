using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public class Portfolio : ApiEndpointBase
    {
        public Portfolio(AuthToken  token) : base("Portfolio", token.AccessToken)
        {
        }
    }
}
