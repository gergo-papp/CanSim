using System;

namespace CanSimulator.Execution
{
    public class Timer
    {
        private readonly CanSimulator _simulator;

        internal Timer(CanSimulator simulator)
        {
            _simulator = simulator;
        }

        public int SimulationLength { get; set; }

        private void TimerEnded()
        {
            _simulator.Stop();
        }

    }
}