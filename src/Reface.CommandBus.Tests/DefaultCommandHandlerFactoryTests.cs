using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.CommandBus.Tests.CommandHandlers;
using Reface.CommandBus.Tests.Commands;

namespace Reface.CommandBus.Tests
{
    [TestClass]
    public class DefaultCommandHandlerFactoryTests
    {
        [TestMethod]
        public void RegisterAsCreatorAndDoNotThrowError()
        {
            DefaultCommandHandlerFactory defaultCommandHandlerFactory = new DefaultCommandHandlerFactory();
            defaultCommandHandlerFactory
                .Register<NewUserCommand>(() => new NewUserCommandHandler());
        }

        [TestMethod]
        public void RegisterAsInstanceAndDoNotThrowError()
        {
            DefaultCommandHandlerFactory defaultCommandHandlerFactory = new DefaultCommandHandlerFactory();
            defaultCommandHandlerFactory
                .Register<NewUserCommand>(new NewUserCommandHandler());
        }

        [TestMethod]
        public void RegisterAsGenericAndDoNotThrowError()
        {
            DefaultCommandHandlerFactory defaultCommandHandlerFactory = new DefaultCommandHandlerFactory();
            defaultCommandHandlerFactory
                .Register<NewUserCommand, NewUserCommandHandler>();
        }
    }
}
