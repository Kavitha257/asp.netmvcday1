using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.netmvcday1.Startup))]
namespace asp.netmvcday1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
