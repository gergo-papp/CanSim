using System;
using CanSimulator.Model.Node.Utils;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Node.Components
{
    public class CanTransceiver : IObservable<Bit>, IObserver<Bit>
    {
        private CanController _controller;
        private IObserver<Bit> _busObserver;
        private Bit _value;

        public CanTransceiver()
        {
        }

        internal CanTransceiver(CanController controller) : this()
        {
            SetController(controller);
        }

        public void SetController(CanController controller)
        {
            _controller = controller;
        }

        public Bit Read()
        {
            return _value;
        }

        public void Write(Bit vaue)
        {
            _busObserver.OnNext(vaue);
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
            _controller.ReceiveBit(_value);
        }
    }
}