namespace Reface.CommandBus.IntegrateAutofac.Tests.Commands
{
    public interface BCommand : ICommand
    {
        string BResult { set; }
    }
}
