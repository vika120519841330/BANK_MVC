using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BANK_MVC_ONION_DI.Startup))]
namespace BANK_MVC_ONION_DI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
