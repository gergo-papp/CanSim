using System;
using System.Collections;
using System.Linq;

namespace CanSimulator.Model.Signal
{
    public class Utils
    {
        internal static void ConvertToBitArray(BitArray bitArray, int number)
        {
            BitArray b = new BitArray(new int[] { number });

            bool[] bits = new bool[b.Count];
            b.CopyTo(bits, 0);

            byte[] bitValues = bits.Select(bit => (byte) (bit ? 1 : 0)).ToArray();
            bitArray = new BitArray(bitValues);
        }

        internal static int ToInt( BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}