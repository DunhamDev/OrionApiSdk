using Owin;

namespace OrionApiSdk.Owin.Provider.Orion
{
    public static class OrionAuthenticationExtensions
    {
        public static IAppBuilder UseOrionAuthentication(this IAppBuilder app, OrionAuthenticationOptions options)
        {
            return app.Use(typeof(OrionAuthenticationMiddleware), app, options);
        }
    }
}
