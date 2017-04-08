namespace CanSim.Model.Signal.Components
{
    public class Bit
    {
        public bool Value { get; set; }

        public Bit()
        {
        }

        public Bit(bool defaultValue) : this()
        {
            Value = defaultValue;
        }
    }
}