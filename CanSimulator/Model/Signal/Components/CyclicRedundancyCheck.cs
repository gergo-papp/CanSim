using System.Collections;

namespace CanSimulator.Model.Signal.Components
{
    public class CyclicRedundancyCheck
    {
        private const int CRCLength = 15;

        public BitArray CRC { get; set; }

        internal CyclicRedundancyCheck()
        {
            CRC = new BitArray(CRCLength);
        }
    }
}