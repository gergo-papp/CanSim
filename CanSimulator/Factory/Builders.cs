using CanSimulator.Model.Node;
using CanSimulator.Model.Node.Components;

namespace CanSimulator.Factory
{
    public class Builders
    {
        internal Builders() { }

        public NodeSessionBuilder NodeSessionBuilder => new NodeSessionBuilder();
    }
}