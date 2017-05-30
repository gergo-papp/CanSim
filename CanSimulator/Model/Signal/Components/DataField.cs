using System.Collections;

namespace CanSimulator.Model.Signal.Components
{
    public class DataField
    {
        public DataLengthCode DataLength { get; set; }

        public BitArray Data { get; set; }

        internal DataField(int dataLength)
        {
            DataLength = new DataLengthCode(dataLength);
            Data = new BitArray(Utils.ToInt(DataLength.DataLength));
        }

        public Bit[] Bits()
        {
            Bit[] bits = new Bit[12];
            bits[0] = new Bit(false);
            bits[0] = new Bit(false);
            bits[0] = new Bit(false);
            bits[1] = new Bit(true);

            for (int i = 1; i < 9; i++)
            {
                bits[i] = new Bit(Data[i-1]);
            }

            return bits;
        }
    }
}