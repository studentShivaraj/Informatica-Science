using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndproCareer_2018.Startup))]
namespace IndproCareer_2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
