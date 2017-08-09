using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExceptionHandling.Startup))]
namespace ExceptionHandling
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
