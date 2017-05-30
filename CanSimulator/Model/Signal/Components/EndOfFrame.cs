using System.Collections;

namespace CanSimulator.Model.Signal.Components
{
    public class EndOfFrame
    {
        private const int EOFLength = 7;

        public BitArray EOF { get; set; }

        internal EndOfFrame()
        {
            EOF = new BitArray(EOFLength, true);
        }

        public Bit[] Bits()
        {
            Bit[] bits = new Bit[EOFLength];
            for (int i = 0; i < EOFLength; i++)
            {
                bits[i] = new Bit(EOF[i]);
            }

            return bits;
        }
    }
}