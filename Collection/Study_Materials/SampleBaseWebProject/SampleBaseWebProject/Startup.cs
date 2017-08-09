using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleBaseWebProject.Startup))]
namespace SampleBaseWebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
