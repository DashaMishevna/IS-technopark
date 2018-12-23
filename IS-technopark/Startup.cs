using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IS_technopark.Startup))]
namespace IS_technopark
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
