using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OAuthTestingApp.Startup))]
namespace OAuthTestingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
