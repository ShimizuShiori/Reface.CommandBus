namespace Reface.CommandBus.IntegrateAutofac.Tests.Commands
{
    public interface ACommand : ICommand
    {
        string AResult { set; }
    }
}
