using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyWithEntity.Startup))]
namespace VidlyWithEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
