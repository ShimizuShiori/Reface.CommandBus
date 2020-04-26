using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.CommandBus.Tests.CommandHandlers;
using Reface.CommandBus.Tests.Commands;
using Reface.CommandBus.Tests.Models;

namespace Reface.CommandBus.Tests
{
    [TestClass]
    public class CommandBusTests
    {
        private ICommandBus GetCommandBus()
        {
            DefaultCommandHandlerFactory factory = new DefaultCommandHandlerFactory();
            factory
                .Register<ISetRoleNameCommand>(() => new SetRoleNameCommandHandler())
                .Register<ISetUserNameCommand>(() => new SetUserNameCommandHandler())
                .Register<ISetDepNameCommand>(() => new SetDeptNameCommandHandler())
                .Register<HelloCommand>(() => new HelloCommandHandler());
            ;
            return new DefaultCommandBus(factory);
        }

        [TestMethod]
        public void DispatchMixedInterfaceCommand()
        {
            ICommandBus commandBus = GetCommandBus();
            for (int i = 1; i < 11; i++)
            {
                User user = new User(i, i * 10);
                commandBus.Dispatch(user);
                Assert.AreEqual($"UserOf{i}", user.UserName);
                Assert.AreEqual($"RoleOf{i * 10}", user.RoleName);
            }
        }

        [TestMethod]
        public void DispatchClassCommand()
        {
            ICommandBus commandBus = GetCommandBus();
            HelloCommand command = new HelloCommand("Felix");
            commandBus.Dispatch(command);
            Assert.AreEqual("Hello Felix", command.Text);
        }
    }
}
