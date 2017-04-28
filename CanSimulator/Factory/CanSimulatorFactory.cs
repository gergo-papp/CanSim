using CanSimulator.Model;

namespace CanSimulator.Factory
{
    public class CanSimulatorFactory
    {
        private readonly Network _network;

        internal CanSimulatorFactory(Network network)
        {
            _network = network;
        }

        public Execution.CanSimulator CanSimulator => new Execution.CanSimulator(_network);
    }
}