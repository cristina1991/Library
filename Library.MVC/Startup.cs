using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.MVC.Startup))]
namespace Library.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
