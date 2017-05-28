using System;
using CanSimulator.MicroControllers;
using CanSimulator.Model;
using CanSimulator.Model.Bus;
using CanSimulator.Model.Node;
using CanSimulator.Model.Node.Components;
using CanSimulator.Model.Node.Utils;
using CanSimulator.Model.Signal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanSimulator.UnitTests.Model
{
    [TestClass]
    public class NetworkTest
    {
        [TestMethod]
        public void AddNodeSessionTest()
        {
            var canSession = Utils.GetNewCanSession();
            var network = new Network(new CanBus(), 1000);

            network.AddNodeSession(canSession, ConnectionState.Disconnected);
            Assert.IsTrue(network.NodeSessions.Contains(canSession));

        }

        [TestMethod]
        public void RemoveNodeSessionTest()
        {
            var canSession = Utils.GetNewCanSession();
            var network = new Network(new CanBus(), 1000);

            network.AddNodeSession(canSession, ConnectionState.Disconnected);
            Assert.IsTrue(network.NodeSessions.Contains(canSession));

            network.RemoveNodeSession(canSession);
            Assert.IsFalse(network.NodeSessions.Contains(canSession));
        }

        [TestMethod]    
         public void RemoveAllNodeSessionsTest()
        {
            var canSession = Utils.GetNewCanSession();
            var canSession1 = Utils.GetNewCanSession();
            var canSession2 = Utils.GetNewCanSession();
            var network = new Network(new CanBus(), 1000);

            network.AddNodeSession(canSession, ConnectionState.Disconnected);
            network.AddNodeSession(canSession1, ConnectionState.Disconnected);
            network.AddNodeSession(canSession2, ConnectionState.Disconnected);
            Assert.IsTrue(network.NodeSessions.Contains(canSession));
            Assert.IsTrue(network.NodeSessions.Contains(canSession1));
            Assert.IsTrue(network.NodeSessions.Contains(canSession2));

            network.RemoveAllNodeSessions();
            Assert.AreEqual(0, network.NodeSessions.Count);
        }

        [TestMethod]
        public void ConnectCanNodeSessionTest()
        {
            var canSession = Utils.GetNewCanSession();
            var network = new Network(new CanBus(), 1000);

            network.AddNodeSession(canSession, ConnectionState.Disconnected);
            network.ConnectCanNodeSession(canSession);

            network.Bus.StartNewTransmission();
        }

        [TestMethod]
        public void ConnectAllCanNodeSessionsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DisconnectCanNodeSessionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DisconnectAllCanNodeSessionsTest()
        {
            throw new NotImplementedException();
        }
    }
}