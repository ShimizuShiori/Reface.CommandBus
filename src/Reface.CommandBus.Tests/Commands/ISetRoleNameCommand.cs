namespace Reface.CommandBus.Tests.Commands
{
    public interface ISetRoleNameCommand : ICommand
    {
        int RoleId { get; }
        string RoleName { set; }
    }
}
