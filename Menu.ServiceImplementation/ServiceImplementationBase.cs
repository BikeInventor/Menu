using System;
using System.ServiceModel;
using Menu.Business.Exceptions;
using Menu.Contracts.DataContracts;

namespace Menu.ServiceImplementation
{
    public abstract class ServiceImplementationBase
    {
        protected T ExecuteWithExceptionHandling<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (ObjectNotFoundException e)
            {
                throw new FaultException<NotFoundException>(new NotFoundException()
                {
                    Title = e.Title,
                    Message = e.Message
                });
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

        protected void ExecuteWithExceptionHandling(Action action)
        {
            try
            {
                action();
            }
            catch (ObjectNotFoundException e)
            {
                throw new FaultException<NotFoundException>(new NotFoundException()
                {
                    Title = e.Title,
                    Message = e.Message
                });
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }
    }
}
