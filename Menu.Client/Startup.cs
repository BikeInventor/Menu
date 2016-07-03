using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Menu.Client.Startup))]
namespace Menu.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
