using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PumpkinPatchApp.Startup))]
namespace PumpkinPatchApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
