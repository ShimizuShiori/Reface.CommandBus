using Reface.CommandBus.Tests.Commands;

namespace Reface.CommandBus.Tests.Models
{
    public class User : ISetUserNameCommand, ISetRoleNameCommand
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public string UserName { get; set; }

        public User(int userId, int roleId)
        {
            this.UserId = userId;
            this.RoleId = roleId;
        }
    }
}
