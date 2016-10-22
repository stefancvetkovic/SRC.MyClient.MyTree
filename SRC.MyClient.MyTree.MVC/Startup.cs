using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SRC.MyClient.MyTree.MVC.Startup))]
namespace SRC.MyClient.MyTree.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
