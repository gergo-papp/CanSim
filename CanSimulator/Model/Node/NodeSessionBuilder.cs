using CanSimulator.Model.Node.Components;

namespace CanSimulator.Model.Node
{
    public class NodeSessionBuilder
    {
        internal NodeSessionBuilder()
        {
        }

        public CanNodeSession CreateCanNodeSession(IMicrocontroller microcontroller) => new CanNodeSession(new CanNode(microcontroller, new CanTransceiver()));
    }
}