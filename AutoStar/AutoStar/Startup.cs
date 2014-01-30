using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoStar.Startup))]
namespace AutoStar
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
