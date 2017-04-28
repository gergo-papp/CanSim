using CanSimulator.Model;

namespace CanSimulator.Factory
{
    public class Factory
    {
        public NetworkFactory CreateNetworkFactory() => new NetworkFactory();
        public CanSimulatorFactory CreateCanSimulatorFactory(Network network) => new CanSimulatorFactory(network);
        public Builders CreateBuilders() => new Builders();
    }
}