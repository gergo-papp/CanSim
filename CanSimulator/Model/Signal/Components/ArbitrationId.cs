using System.Collections;

namespace CanSimulator.Model.Signal.Components
{
    public class ArbitrationId
    {
        private const int ArbitrationLength = 11;

        public BitArray Identifier { get; set; }

        internal ArbitrationId(int id)
        {
            Identifier = new BitArray(ArbitrationLength);
            Utils.ConvertToBitArray(Identifier, id);
        }

        public bool Equals(ArbitrationId id)
        {
            return id.Identifier.Equals(this.Identifier);
        }

        public Bit[] Bits()
        {
            Bit[] bits = new Bit[ArbitrationLength];
            for (int i = 0; i < ArbitrationLength; i++)
            {
                bits[i] = new Bit(Identifier[i]);
            }

            return bits;
        }
    }
}