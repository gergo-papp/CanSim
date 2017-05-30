using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CanSimulator.Model.Node.Components;
using CanSimulator.Model.Signal;
using CanSimulator.Model.Signal.Components;

namespace CanSimulator.MicroControllers
{
    public class RpmDashboardIndicatorMicroController : IMicrocontroller
    {
        private bool _running = true;
        private readonly ArbitrationId _sensorId = new ArbitrationId(18);

        public CanController CanController { get; set; }
        public void Run()
        {
            while (_running)
            {
                // Do nothing. We are not sending data...
            }
        }

        public void ReceiveData(Frame frame)
        {
            if (frame.Identifier.Equals(_sensorId) || true)
            {
                int rpm = 0;

                Console.WriteLine($"[Dashboard] Received new RPM value: {rpm}.");
            }
        }
    }
}
