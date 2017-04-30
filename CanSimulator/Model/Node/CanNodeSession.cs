using System;
using System.Threading;
using CanSimulator.Model.Node.Components;

namespace CanSimulator.Model.Node
{
    public class CanNodeSession
    {
        public CanNode CanNode { get; }
        public IDisposable CanBusUnubscription { get; set; }
        private Thread ControllerThread { get; set; }

        internal CanNodeSession(CanNode canNode)
        {
            CanNode = canNode;
        }

        public void Start()
        {
            if (ControllerThread != null)
            {
                Stop();
            }

            ControllerThread = new Thread(CanNode.MicroController.Run);
            ControllerThread.Start();
        }

        public void Stop()
        {
            ControllerThread?.Abort();
            ControllerThread = null;
        }
    }
}