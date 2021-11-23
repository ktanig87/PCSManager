using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCSManager.WebMVC.Startup))]
namespace PCSManager.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
