using System.Threading;
using CanSimulator.Factory;
using CanSimulator.MicroControllers;
using CanSimulator.Model.Node;
using CanSimulator.Model.Node.Utils;

namespace TestRunner
{
    public static class Program
    {
        public static void Main()
        {
            var factory = new Factory();
            var networkFactory = factory.CreateNetworkFactory();
            var network = networkFactory.Network;
            var canSimulatorFactory = factory.CreateCanSimulatorFactory(network);
            var builder = factory.CreateBuilders();

            var canSimulator = canSimulatorFactory.CanSimulator;
            var nodeBuilder = builder.NodeSessionBuilder;
            var controllerBuilder = builder.CanControllerBuilder;

            var nodeSession1 = nodeBuilder.CreateCanNodeSession(new MockMicroControllerImpl(controllerBuilder.CanController));
            var nodeSession2 = nodeBuilder.CreateCanNodeSession(new MockMicroControllerImpl(controllerBuilder.CanController));
            var nodeSession3 = nodeBuilder.CreateCanNodeSession(new MockMicroControllerImpl(controllerBuilder.CanController));

            network.AddNodeSession(nodeSession1, ConnectionState.Connected);
            network.AddNodeSession(nodeSession2, ConnectionState.Connected);
            network.AddNodeSession(nodeSession3, ConnectionState.Connected);


            canSimulator.RunFor(10000);

            Thread.Sleep(15000);
            canSimulator.Stop();
        }
    }
}
