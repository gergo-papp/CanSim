using System;
using System.Collections.Generic;
using System.Threading;
using CanSim.Model.Node.Components;
using CanSim.Model.Signal.Components;

namespace CanSim.Model.Bus
{
    public class CanBus : IObserver<Bit>, IObservable<Bit>
    {
        private Bit _currentValue;
        private readonly object _lock;
        private ISet<IObserver<Bit>> _canObservers;

        public CanBus()
        {
            _currentValue = null;
            _lock = new object();
            _canObservers = new HashSet<IObserver<Bit>>();
        }

        public void StartNewTransmission()
        {
            lock (_lock)
            {
                 _currentValue = null;
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
                    if (value.Value == false || _currentValue.Value == false) // "0" is dominant so we assign it if any value is "0"
                    {
                        _currentValue.Value = false;
                    }
                    else
                    {
                        _currentValue.Value = true; // We only assign "1" if "0" is not beeing assigned
                    }
                }
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