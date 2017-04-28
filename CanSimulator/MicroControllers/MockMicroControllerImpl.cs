using System;
using System.Threading;
using CanSimulator.Model.Node.Components;

namespace CanSimulator.MicroControllers
{
    public class MockMicroControllerImpl : IMicrocontroller
    {
        private bool _running = true;

        public CanController CanController { get; }

        public MockMicroControllerImpl(CanController canController)
        {
            CanController = canController;
        }

        public void Run()
        {
            while (_running)
            {
                Console.WriteLine("Runnig...");
                Thread.Sleep(1000);
                
            }
        }
    }
}