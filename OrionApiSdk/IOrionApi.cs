using OrionApiSdk.ApiEndpoints.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk
{
    public interface IOrionApi
    {
        IAuthorizationEndpoint Authorization { get; }
    }
}
