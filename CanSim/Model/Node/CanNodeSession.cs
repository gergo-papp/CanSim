using System.Threading;
using CanSim.Model.Node.Components;

namespace CanSim.Model.Node
{
    public class CanNodeSession
    {
        public CanNode CanNode { get; }
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