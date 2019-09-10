using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JantaTechForRetailShop.Startup))]
namespace JantaTechForRetailShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
