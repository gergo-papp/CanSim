using System;
using CanSim.Model.Signal.Components;

namespace CanSim.Model.Node
{
    public class Unsubscriber : IDisposable
    {
        private readonly IObserver<Bit> _busObserver;

        public Unsubscriber(IObserver<Bit> busObserver)
        {
            _busObserver = busObserver;
        }

        public void Dispose()
        {
            _busObserver.OnCompleted();
        }
    }
}