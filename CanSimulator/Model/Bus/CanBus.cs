using System;
using System.Collections.Generic;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Bus
{
    public class CanBus : IObserver<Bit>, IObservable<Bit>
    {
        private Bit _currentValue;
        private readonly object _lock;
        private readonly ISet<IObserver<Bit>> _canObservers;

        internal CanBus()
        {
            _currentValue = null;
            _lock = new object();
            _canObservers = new HashSet<IObserver<Bit>>();
        }

        public void StartNewTransmission()
        {
            lock (_lock)
            {
                _currentValue = new Bit(true); // "1" is recessive so we assign it by default. "1" is also the idle state of the bus.
                foreach (var canObserver in _canObservers)
                {
                    canObserver.OnNext(_currentValue);
                }
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Bit value)
        {
            lock (_lock)
            {
                if (ReferenceEquals(_currentValue, null))
                {
                    _currentValue = value;
                }
                else
                {
                    if (value == null)
                    {
                        value = new Bit(false);
                    }

                    _currentValue.Value = value.Value;

                    /*if (value.Value == false || _currentValue.Value == false) // "0" is dominant so we assign it if any value is "0"
                    {
                        _currentValue.Value = false;
                    }
                    else
                    {
                        _currentValue.Value = true; // We only assign "1" if "0" is not being assigned
                    }*/
                }
            }

            if (_currentValue.Value)
            {
                Console.Write("0");
            }
            else
            {
                Console.Write("1");
            }
        }

        public IDisposable Subscribe(IObserver<Bit> observer)
        {
            if (!_canObservers.Contains(observer))
            {
                _canObservers.Add(observer);
            }

            return new Unsubscriber(_canObservers, observer);
        }
    }
}