using CanSimulator.Model;
using CanSimulator.Model.Bus;

namespace CanSimulator.Factory
{
    public class NetworkFactory
    {
        public int BitRate { get; set; } = 100;

        public Network Network => new Network(new CanBus(), BitRate);
    }
}