using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class PortfolioEndpoint : ApiEndpointBase
    {
        public PortfolioEndpoint(AuthToken token) : base("Portfolio", token)
        {
        }

        private RepresentativesMethods _repMethods;
        public RepresentativesMethods Representatives
        {
            get
            {
                return _repMethods ?? (_repMethods = new RepresentativesMethods(AuthToken));
            }
        }
    }
}
