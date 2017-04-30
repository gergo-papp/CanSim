using System;
using System.Data.SqlTypes;
using CanSimulator.Model;

namespace CanSimulator.Execution
{
    public class CanSimulator
    {
        private readonly Network _network;
        private const int DefaultTime = 10000;
        private readonly System.Timers.Timer _timer;

        internal CanSimulator(Network network)
        {
            _network = network;
            _timer = new System.Timers.Timer()
            {
                AutoReset = false,
                Enabled = true,
                Interval = DefaultTime
            };

            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();
            Stop();
        }

        public void Run()
        {
            Console.WriteLine($"Running simulation for {DefaultTime} seconds.");
            _network.StartNetwork();
            _timer.Start();
        }

        public void RunFor(int ms)
        {
            _timer.Interval = ms;

            Console.WriteLine($"Running simulation for {ms} milliseconds.");
            _network.StartNetwork();
            _timer.Start();
        }

        public void Stop()
        {
            _network.StopNetwork();
            Console.WriteLine($"Stopped simulation.");
        }
    }
}