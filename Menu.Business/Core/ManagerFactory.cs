using Menu.Common;

namespace Menu.Business.Core
{
    public class ManagerFactory
    {
        public static T GetManager<T>()
        {
            return Dependencies.Container.Resolve<T>();
        }
    }
}
