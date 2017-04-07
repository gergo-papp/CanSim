using System;
using System.Threading;
using CanSim.Model.Node;
using CanSim.Model.Node.Components;

namespace CanSim.MicroControllers
{
    public class MockMicroControllerImpl : IMicrocontroller
    {
        public CanController CanController { get; }

        public MockMicroControllerImpl(CanController canController)
        {
            CanController = canController;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Runnig...");
                Thread.Sleep(1000);
            }
        }
    }
}