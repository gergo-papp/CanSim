using System;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Node.Utils
{
    public class Unsubscriber : IDisposable
    {
        private readonly IObserver<Bit> _busObserver;

        internal Unsubscriber(IObserver<Bit> busObserver)
        {
            _busObserver = busObserver;
        }

        public void Dispose()
        {
            _busObserver.OnCompleted();
        }
    }
}