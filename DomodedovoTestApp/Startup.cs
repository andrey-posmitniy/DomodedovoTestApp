using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DomodedovoTestApp.Startup))]
namespace DomodedovoTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
