using System;
using System.Data.SqlTypes;
using CanSimulator.Model;

namespace CanSimulator.Execution
{
    public class CanSimulator
    {
        private readonly Network _network;
        private const int DefaultTime = 10;
        private readonly Timer _timer;

        internal CanSimulator(Network network)
        {
            _network = network;
            _timer = new Timer(this);
        }

        public void Run()
        {
            _timer.SimulationLength = DefaultTime;
            Console.WriteLine($"Running simulation for {DefaultTime} seconds.");
            _network.StartNetwork();
        }

        public void RunFor(int sec)
        {
            _timer.SimulationLength = sec;
            Console.WriteLine($"Running simulation for {sec} seconds.");
            _network.StartNetwork();
        }

        public void Stop()
        {
            _network.StopNetwork();
            Console.WriteLine($"Stopped simulation.");
        }
    }
}