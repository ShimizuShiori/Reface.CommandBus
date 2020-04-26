using Reface.CommandBus.Tests.Commands;
using System;

namespace Reface.CommandBus.Tests.CommandHandlers
{
    public class SetRoleNameCommandHandler : ICommandHandler<ISetRoleNameCommand>
    {
        public void Handle(ISetRoleNameCommand command)
        {
            command.RoleName = string.Format("RoleOf{0}", command.RoleId);
        }
    }
}
