using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.Core
{
    public abstract class ManagerBase
    {
        protected ManagerBase()
        {

        }

        protected T ExecuteWithFaultHandling<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

        protected void ExecuteWithFaultHandling(Action action)
        {
            try
            {
                action();
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }
    }
}
