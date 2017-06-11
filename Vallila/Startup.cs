using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vallila.Startup))]
namespace Vallila
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
