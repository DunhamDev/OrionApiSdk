using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public abstract class ApiMethodContainer : ApiEndpointBase
    {
        internal ApiMethodContainer(string apiEndpointName, string apiEndpointContainerMethod, AuthToken token)
            : base(apiEndpointName + "/" + apiEndpointContainerMethod, token) { }
    }
}
