using System.Collections;

namespace CanSim.Model.Signal.Components
{
    public class ArbitrationId
    {
        private const int ArbitrationLength = 11;

        public BitArray Identifier { get; set; }

        public ArbitrationId(int id)
        {
            Identifier = new BitArray(ArbitrationLength);
            Utils.ConvertToBitArray(Identifier, id);
        }
    }
}