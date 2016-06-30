using Menu.Common;
using Menu.Bootstrapper;
using Menu.Service.Mappings;

namespace Menu.Service.App_Code
{
    public class Initializer
    {
        public static void AppInitialize()
        {
            Dependencies.InitContainer(IoCInitializer.GetInitializedContainer());
            AutoMapperConfiguration.Configure();
        }
    }
}