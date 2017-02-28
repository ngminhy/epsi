using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(epsi.Startup))]
namespace epsi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
