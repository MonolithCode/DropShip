using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonolithDS.WebUI.Startup))]
namespace MonolithDS.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
