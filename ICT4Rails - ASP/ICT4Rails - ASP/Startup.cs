using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICT4Rails___ASP.Startup))]
namespace ICT4Rails___ASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
