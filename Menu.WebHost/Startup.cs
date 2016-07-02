using System;
using System.Threading.Tasks;
using Menu.Common;
using Menu.IoCLoader;
using Menu.Service.Mappings;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Menu.WebHost.Startup))]

namespace Menu.WebHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Dependencies.InitContainer(IoCInitializer.GetContainer(ApplicationType.Service));
            AutoMapperConfiguration.Configure();
        }
    }
}
