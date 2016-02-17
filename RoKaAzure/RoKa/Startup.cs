using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoKa.Startup))]
namespace RoKa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
