using System;
using System.Threading;
using CanSim.Model.Node.Components;

namespace CanSim.Model.Node
{
    public class CanNodeSession
    {
        public CanNode CanNode { get; }
        public IDisposable CanBusUnubscription { get; set; }
        private Thread ControllerThread { get; set; }

        public CanNodeSession(CanNode canNode)
        {
            CanNode = canNode;
            ControllerThread = new Thread(CanNode.MicroController.Run);
        }

        public void Start()
        {
            ControllerThread.Start(); 
        }
    }
}