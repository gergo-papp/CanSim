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
    }
}