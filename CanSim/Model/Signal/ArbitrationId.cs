using System;
using System.Collections;

namespace CanSim.Model.Signal
{
    public class ArbitrationId
    {
        private const int ArbitrationLength = 11;

        public BitArray Id { get; set; }

        public ArbitrationId(int id)
        {
            Id = new BitArray(ArbitrationLength);
            Utils.ConvertToBitArray(Id, id);
        }
    }
}