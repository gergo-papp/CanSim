namespace CanSimulator.Model.Signal.Components
{
    public class Bit
    {
        public bool Value { get; set; }

        public Bit()
        {
        }

        internal Bit(bool defaultValue) : this()
        {
            Value = defaultValue;
        }
    }
}