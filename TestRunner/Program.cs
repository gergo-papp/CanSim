using System;
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

            var sensor = nodeBuilder.CreateCanNodeSession(typeof(RpmSensorMicroController));
            var dashboard = nodeBuilder.CreateCanNodeSession(typeof(RpmDashboardIndicatorMicroController));

            network.AddNodeSession(sensor, ConnectionState.Connected);
            network.AddNodeSession(dashboard, ConnectionState.Connected);


            canSimulator.RunFor(10000);

            Thread.Sleep(15000);
            Console.ReadKey();
        }
    }
}
