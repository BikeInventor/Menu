
using Menu.Common;

namespace Menu.Proxies.Core
{
    public class ProxyFactory : IProxyFactory
    {
        public T GetProxy<T>()
        {
            return Dependencies.Container.Resolve<T>();
        }
    }
}
