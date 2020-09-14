using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ar306514_MIS4200.Startup))]
namespace ar306514_MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
