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
    }
}