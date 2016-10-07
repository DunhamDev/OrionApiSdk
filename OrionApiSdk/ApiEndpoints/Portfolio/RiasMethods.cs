using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class RiasMethods : ApiMethodContainer
    {
        public RiasMethods(AuthToken token) : base("Portfolio", "Rias", token) { }
    }
}
