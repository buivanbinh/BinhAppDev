using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asm1appdev.Startup))]
namespace asm1appdev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
