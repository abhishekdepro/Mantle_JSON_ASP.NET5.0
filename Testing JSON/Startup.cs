using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testing_JSON.Startup))]
namespace Testing_JSON
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
