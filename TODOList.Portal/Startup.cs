using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TODOList.Portal.Startup))]
namespace TODOList.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
