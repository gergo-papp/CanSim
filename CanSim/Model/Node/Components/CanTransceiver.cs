using System;
using CanSim.Model.Signal.Components;

namespace CanSim.Model.Node.Components
{
    public class CanTransceiver : IObservable<Bit>, IObserver<Bit>
    {
        private IObserver<Bit> _busObserver;

        public IDisposable Subscribe(IObserver<Bit> observer)
        {
            _busObserver = observer;
            return new Unsubscriber(_busObserver);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Disconnected from Bus");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Bit value)
        {
            throw new NotImplementedException();
        }
    }
}