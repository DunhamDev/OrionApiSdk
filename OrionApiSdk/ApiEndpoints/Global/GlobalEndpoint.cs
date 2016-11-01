using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Global
{
    public class GlobalEndpoint : ApiEndpointBase
    {
        public GlobalEndpoint(AuthToken token) : base("Global", token) { }
        public GlobalEndpoint(AuthToken token, bool useTestingApi) : base("Global", token, useTestingApi) { }
    }
}
