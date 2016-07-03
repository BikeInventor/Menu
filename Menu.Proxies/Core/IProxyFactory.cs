using Menu.Contracts;

namespace Menu.Proxies.Core
{
    public interface IProxyFactory
    {
        T GetProxy<T>() where T : IServiceContract;
    }
}
