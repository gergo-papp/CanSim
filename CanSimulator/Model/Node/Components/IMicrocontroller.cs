using CanSimulator.Model.Signal;

namespace CanSimulator.Model.Node.Components
{
    /// <summary>
    /// It is required that a Micro-controller has a parameterless constructor
    /// </summary>
    public interface IMicrocontroller
    {
        CanController CanController { get; set; }

        void Run();
        void ReceiveData(Frame frame);
    }
}