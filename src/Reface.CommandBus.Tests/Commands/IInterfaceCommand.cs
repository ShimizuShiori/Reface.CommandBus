namespace Reface.CommandBus.Tests.Commands
{
    public interface IInterfaceCommand : ICommand
    {
        string Name { get; }

        string Text { set; }
    }
}
