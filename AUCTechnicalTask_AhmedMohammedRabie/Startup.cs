using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AUCTechnicalTask_AhmedMohammedRabie.Startup))]
namespace AUCTechnicalTask_AhmedMohammedRabie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
