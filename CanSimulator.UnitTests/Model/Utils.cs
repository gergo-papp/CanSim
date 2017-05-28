using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanSimulator.MicroControllers;
using CanSimulator.Model.Node;
using CanSimulator.Model.Node.Components;
using CanSimulator.Model.Signal;

namespace CanSimulator.UnitTests.Model
{
    internal class Utils
    {
        internal static CanNodeSession GetNewCanSession()
        {
            var canController = new CanController();
            var microController = new MockMicroControllerImpl(canController);
            var transceiver = new CanTransceiver(canController);
            canController.SetControllerProperties(transceiver, microController, new FrameBuilder());

            return new CanNodeSession(new CanNode(microController, transceiver));
        }
    }
}
