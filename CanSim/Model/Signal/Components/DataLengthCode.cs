﻿using System.Collections;

namespace CanSim.Model.Signal.Components
{
    public class DataLengthCode
    {
        private const int DataLengthCodeLength = 4;

        public BitArray DataLength { get; set; }

        public DataLengthCode(int dataLength)
        {
            DataLength = new BitArray(DataLengthCodeLength);
            Utils.ConvertToBitArray(DataLength, dataLength);
        }
    }
}