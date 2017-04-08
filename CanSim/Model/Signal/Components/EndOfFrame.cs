using System.Collections;

namespace CanSim.Model.Signal.Components
{
    public class EndOfFrame
    {
        private const int EOFLength = 7;

        public BitArray EOF { get; set; }

        public EndOfFrame()
        {
            EOF = new BitArray(EOFLength, true);
        }
    }
}