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

        public Bit[] Bits()
        {
            Bit[] bits = new Bit[CRCLength];
            for (int i = 0; i < CRCLength; i++)
            {
                bits[i] = new Bit(CRC[i]);
            }

            return bits;
        }
    }
}