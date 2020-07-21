using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BundleGames.Startup))]
namespace BundleGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
