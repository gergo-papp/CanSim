using System;
using System.Threading;
using CanSimulator.Model.Node.Components;

namespace CanSimulator.MicroControllers
{
    public class MockMicroControllerImpl : IMicrocontroller
    {
        private bool _running = true;

        public CanController CanController { get; set; }


        public MockMicroControllerImpl()
        {
        }

        public MockMicroControllerImpl(CanController canController) : this()
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