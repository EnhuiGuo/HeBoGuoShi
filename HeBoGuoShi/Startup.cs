using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeBoGuoShi.Startup))]
namespace HeBoGuoShi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
