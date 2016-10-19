using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Owin.Providers.Orion
{
    public static class OrionAuthenticationExtensions
    {
        public static IAppBuilder UseOrionAuthentication(this IAppBuilder app, OrionAuthenticationOptions options)
        {
            return app.Use(typeof(OrionAuthenticationMiddleware), app, options);
        }
    }
}
