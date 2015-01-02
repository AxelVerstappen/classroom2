using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Classroom2.Startup))]
namespace Classroom2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
