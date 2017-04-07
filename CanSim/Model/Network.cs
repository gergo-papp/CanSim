using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using CanSim.Model.Bus;
using CanSim.Model.Node;

namespace CanSim.Model
{
    public class Network
    {
        private readonly ISet<CanNodeSession> _nodeSessions;

        public CanBus Bus { get; }
        public IImmutableSet<CanNodeSession> NodeSessions => _nodeSessions.ToImmutableHashSet();

        public Network(CanBus bus)
        {
            Bus = bus;
            _nodeSessions = new HashSet<CanNodeSession>();
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
            // TODO: Connect to bus
            throw new NotImplementedException();
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
            // TODO: Disconnect from bus
            throw new NotImplementedException();
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