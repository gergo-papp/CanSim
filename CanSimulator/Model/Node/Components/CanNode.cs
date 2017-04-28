using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Node.Components
{
    public class CanNode
    {
        public IMicrocontroller MicroController { get; }
        public CanTransceiver Transceiver { get; }

        public ArbitrationId Id { get; set; }

        internal CanNode(IMicrocontroller microController, CanTransceiver transceiver)
        {
            MicroController = microController;
            Transceiver = transceiver;
        }


    }
}