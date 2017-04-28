namespace CanSimulator.Model.Node.Components
{
    public interface IMicrocontroller
    {
        CanController CanController { get; }

        void Run();
    }
}