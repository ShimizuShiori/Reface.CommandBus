namespace Reface.CommandBus.Tests.Commands
{
    public interface ISetUserNameCommand : ICommand
    {
        int UserId { get; }
        string UserName { set; }
    }
}
