using System;

namespace CanSim.Model.Node.Components
{
    public class CanNode
    {
        public IMicrocontroller MicroController { get; }
        public CanTransceiver Transceiver { get; }

        public ArbitrationId Id { get; set; }

        public CanNode(IMicrocontroller microController, CanTransceiver transceiver)
        {
            MicroController = microController;
            Transceiver = transceiver;
        }
    }
}