using System;
using CanSimulator.Model.Signal;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Node.Components
{
    public class CanController
    {
        private CanTransceiver _transceiver;
        private IMicrocontroller _owningMicrocontroller;
        private FrameBuilder _frameBuilder;

        internal CanController()
        {
            
        }

        internal void SetControllerProperties(CanTransceiver transceiver, IMicrocontroller owningMicrocontroller, FrameBuilder frameBuilder)
        {
            _transceiver = transceiver;
            _owningMicrocontroller = owningMicrocontroller;
            _frameBuilder = frameBuilder;
        }

        /// <summary>
        /// Called by the CanTransciever to read a new bit.
        /// </summary>
        public void ReceiveBit(Bit bit)
        {
            AddToFrame(bit);
        }

        private void AddToFrame(Bit bit)
        {
            // TODO: add to Frame
            
        }

        private void OnFrameComplete()
        {
            // _owningMicrocontroller.PutNewFrame(builder.getFrame);
            _frameBuilder.Reset();
        }

        /// <summary>
        /// Calls the CanTransciever to write a new bit.
        /// </summary>
        public void SendBit(Bit bit)
        {
            _transceiver.Write(bit);
        }
    }
}