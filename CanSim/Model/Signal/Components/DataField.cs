using System.Collections;

namespace CanSim.Model.Signal.Components
{
    public class DataField
    {
        public DataLengthCode DataLength { get; set; }

        public BitArray Data { get; set; }

        public DataField(int dataLength)
        {
            DataLength = new DataLengthCode(dataLength);
            Data = new BitArray(Utils.ToInt(DataLength.DataLength));
        }
    }
}