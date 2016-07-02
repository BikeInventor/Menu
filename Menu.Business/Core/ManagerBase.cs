using System;
using System.ServiceModel;

namespace Menu.Business.Core
{
    public abstract class ManagerBase
    {

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
