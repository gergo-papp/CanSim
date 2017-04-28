using System;
using CanSimulator.Model.Node.Utils;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Node.Components
{
    public class CanTransceiver : IObservable<Bit>, IObserver<Bit>
    {
        private IObserver<Bit> _busObserver;
        private Bit _value;

        internal CanTransceiver()
        {
        }

        public Bit Read()
        {
            return _value;
        }

        public void Write(Bit vaue)
        {
            OnNext(vaue);
        }

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
            _value = value;
        }
    }
}