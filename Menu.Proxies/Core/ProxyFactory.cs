using Menu.Common;
using Menu.Contracts;

namespace Menu.Proxies.Core
{
    public class ProxyFactory : IProxyFactory
    {
        public T GetProxy<T>() where T : IServiceContract
        {
            return Dependencies.Container.Resolve<T>();
        }
    }
}
