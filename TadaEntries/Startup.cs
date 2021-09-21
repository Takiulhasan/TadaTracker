using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TadaEntries.Startup))]
namespace TadaEntries
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
