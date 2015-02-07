using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plutus.Web.Startup))]
namespace Plutus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
