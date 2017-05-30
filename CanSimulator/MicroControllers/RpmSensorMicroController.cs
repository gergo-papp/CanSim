
using System;
using System.Collections;
using System.Threading;
using CanSimulator.Model.Node.Components;
using CanSimulator.Model.Signal;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.MicroControllers
{
    public class RpmSensorMicroController : IMicrocontroller
    {
        private bool _running = true;

        public CanController CanController { get; set; }

        public void Run()
        {
            while (_running)
            {
                Thread.Sleep(1000);
                var rpmGenerator = new Random();
                Console.WriteLine($"\n[Sensor] Sending new RPM value.");
                CanController.ReceiveFrameFromOwningMicroController(GetRpmFrame(rpmGenerator.Next(-30, 40)));
            }
        }

        private Frame GetRpmFrame(int rpm)
        {
            var frame = new Frame()
            {
                Identifier = new ArbitrationId(18),
                RemoteTransmissionRequest = new Bit(false),
                IdentifierExtensionBit = new Bit(true),
                ReservedBit = new Bit(false),
                Data = new DataField(1)
                {
                    Data = new BitArray(IntegerToByte(rpm))
                },
                CRC = new CyclicRedundancyCheck(),
                CRCDelimiter = new Bit(true),
                ACKSlot = new Bit(true),
                ACKDelimiter = new Bit(true),
                EndOfFrame = new EndOfFrame()
            };

            return frame;
        }

        private BitArray IntegerToByte(int i)
        {
            var bitArray = new BitArray(new int[] { i });
            return bitArray;
        }

        public void ReceiveData(Frame frame)
        {
            // This MicroController doesn't receive frames yet
        }
    }
}
