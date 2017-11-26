using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ahad.Startup))]
namespace Ahad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
