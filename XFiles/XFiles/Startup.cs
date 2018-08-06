using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XFiles.Startup))]
namespace XFiles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
