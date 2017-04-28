using System;
using System.Collections.Generic;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Bus
{
    public class Unsubscriber : IDisposable
    {
        private readonly ISet<IObserver<Bit>> _canObservers;
        private readonly IObserver<Bit> _observer;

        internal Unsubscriber(ISet<IObserver<Bit>> canObservers, IObserver<Bit> observer)
        {
            _canObservers = canObservers;
            _observer = observer;
        }

        public void Dispose()
        {
            _canObservers.Remove(_observer);
            _observer.OnCompleted();
        }
    }
}