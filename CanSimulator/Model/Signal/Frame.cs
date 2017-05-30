using System.Collections;
using System.Collections.Generic;
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

        public IEnumerable<Bit> AllBits()
        {
            List<Bit> allBits = new List<Bit>();
            allBits.Add(StartOfFrame);
            allBits.AddRange(Identifier.Bits());
            allBits.Add(RemoteTransmissionRequest);
            allBits.Add(IdentifierExtensionBit);
            allBits.Add(ReservedBit);
            allBits.AddRange(Data.Bits());
            allBits.Add(CRCDelimiter);
            allBits.Add(ACKSlot);
            allBits.Add(ACKDelimiter);
            allBits.AddRange(EndOfFrame.Bits());

            return allBits;
        }
    }
}