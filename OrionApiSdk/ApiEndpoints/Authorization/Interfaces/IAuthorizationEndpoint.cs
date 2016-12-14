using OrionApiSdk.Objects.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Authorization.Interfaces
{
    public interface IAuthorizationEndpoint : IApiEndpoint
    {
        UserProfile User();
        Task<UserProfile> UserAsync();
    }
}
