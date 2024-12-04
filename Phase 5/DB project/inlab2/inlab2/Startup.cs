using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inlab2.Startup))]
namespace inlab2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
