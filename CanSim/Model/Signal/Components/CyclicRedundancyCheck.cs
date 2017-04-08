using System.Collections;

namespace CanSim.Model.Signal.Components
{
    public class CyclicRedundancyCheck
    {
        private const int CRCLength = 15;

        public BitArray CRC { get; set; }

        public CyclicRedundancyCheck()
        {
            CRC = new BitArray(CRCLength);
        }
    }
}