using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using CanSimulator.Model.Bus;
using CanSimulator.Model.Node;
using CanSimulator.Model.Node.Utils;

namespace CanSimulator.Model
{
    public class Network
    {
        private readonly ISet<CanNodeSession> _nodeSessions;

        public CanBus Bus { get; }
        public int BitRate { get; }
        public IImmutableSet<CanNodeSession> NodeSessions => _nodeSessions.ToImmutableHashSet(); // return only a copy

        internal Network(CanBus bus, int bitRate)
        {
            Bus = bus;
            BitRate = bitRate;
            _nodeSessions = new HashSet<CanNodeSession>();
        }

        internal void StartNetwork()
        {
            foreach (var canNodeSession in _nodeSessions)
            {
                canNodeSession.Start();
            }
        }

        internal void StopNetwork()
        {
            foreach (var canNodeSession in _nodeSessions)
            {
                canNodeSession.Stop();
            }
        }

        public void AddNodeSession(CanNodeSession nodeSession, ConnectionState defaultConnectionState)
        {
            _nodeSessions.Add(nodeSession);

            if (defaultConnectionState == ConnectionState.Connected)
            {
                ConnectCanNodeSession(nodeSession);
            }
        }

        public void RemoveNodeSession(CanNodeSession nodeSession)
        {
            _nodeSessions.Remove(nodeSession);
        }

        public void RemoveAllNodeSessions()
        {
            foreach (var canNodeSession in _nodeSessions)
            {
                _nodeSessions.Remove(canNodeSession);
            }
        }

        public void ConnectCanNodeSession(CanNodeSession nodeSession)
        {
            if (_nodeSessions.Contains(nodeSession))
            {
                nodeSession.CanBusUnubscription = nodeSession.CanNode.Transceiver.Subscribe(Bus);
                Bus.Subscribe(nodeSession.CanNode.Transceiver);
            }
            else
            {
                throw new Exception();
            }
        }

        public void ConnectAllCanNodeSessions()
        {
            foreach (var canNodeSession in _nodeSessions)
            {
                ConnectCanNodeSession(canNodeSession);
            }
        }

        public void DisconnectCanNodeSession(CanNodeSession nodeSession)
        {
            if (_nodeSessions.Contains(nodeSession))
            {
                nodeSession.CanBusUnubscription.Dispose();
            }
            else
            {
                throw new Exception();
            }
        }

        public void DisconnectAllCanNodeSessions()
        {
            foreach (var canNodeSession in _nodeSessions)
            {
                DisconnectCanNodeSession(canNodeSession);
            }
        }
    }
}