namespace Reface.CommandBus.Tests.Commands
{
    public interface ISetDepNameCommand : ICommand
    {
        int DeptId { get; }
        string DeptName { set; }
    }
}
