using CanSimulator.Model.Signal.Components;

namespace CanSimulator.Model.Signal
{
    public class Frame
    {
        public Bit StartOfFrame => new Bit(false);
        public ArbitrationId Identifier { get; set; }
        public Bit RemoteTransmissionRequest { get; set; }
        public Bit IdentifierExtensionBit { get; set; }
        public Bit ReservedBit { get; set; }
        public DataField Data { get; set; }
        public CyclicRedundancyCheck CRC { get; set; }
        public Bit CRCDelimiter { get; set; }
        public Bit ACKSlot { get; set; }
        public Bit ACKDelimiter { get; set; }
        public EndOfFrame EndOfFrame { get; set; }
    }
}