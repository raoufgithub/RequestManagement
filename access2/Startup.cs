using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(view.Startup))]
namespace view
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
