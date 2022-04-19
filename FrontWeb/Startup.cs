using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontWeb.Startup))]
namespace FrontWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
