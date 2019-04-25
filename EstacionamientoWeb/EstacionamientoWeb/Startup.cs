using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstacionamientoWeb.Startup))]
namespace EstacionamientoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
