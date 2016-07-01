using Menu.Common;
using Menu.IoCLoader.App_Code;
using Menu.Service.Mappings;

namespace Menu.Service
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