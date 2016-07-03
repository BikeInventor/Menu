using System;
using System.ServiceModel;

namespace Menu.Proxies.Core
{
    public abstract class DisposableClientBase <T> : IDisposable
        where T : class
    {
        private readonly object _sync = new object();
        private readonly Lazy<T> _channel;

        protected T Channel => _channel.Value;

        protected DisposableClientBase()
        {
            _channel = new Lazy<T>(CreateChannel);
        }

        private T CreateChannel()
        {
            lock (_sync)
            {
                var channelFactory = new ChannelFactory<T>("");
                return channelFactory.CreateChannel();
            }
        }

        protected void Close()
        {
            if (_channel.IsValueCreated)
            {
                (_channel.Value as ICommunicationObject)?.Close();
            }
        }

        protected void Abort()
        {
            if (_channel.IsValueCreated)
            {
                (_channel.Value as ICommunicationObject)?.Abort();
            }
        }

        public void Dispose()
        {
            var success = false;
            try
            {
                var channel = _channel.IsValueCreated ? (_channel.Value as ICommunicationObject) : null;
                if (channel == null)
                    return;

                if (channel.State != CommunicationState.Faulted)
                {
                    Close();
                    success = true;
                }
            }
            finally
            {
                if (!success)
                    Abort();
            }
        }
    }
}
