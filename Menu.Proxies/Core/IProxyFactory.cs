using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Common;

namespace Menu.Proxies.Core
{
    public interface IProxyFactory
    {
        T GetProxy<T>();
    }
}
