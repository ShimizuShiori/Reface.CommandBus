using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.CommandBus.Tests.CommandHandlers;
using Reface.CommandBus.Tests.Commands;

namespace Reface.CommandBus.Tests
{
    [TestClass()]
    public class DefaultCommandBusTests
    {
        [TestMethod]
        public void DispatchAsRegistedByCreator()
        {
            DefaultCommandHandlerFactory defaultCommandHandlerFactory = new DefaultCommandHandlerFactory();
            defaultCommandHandlerFactory
                .Register<NewUserCommand>(() => new NewUserCommandHandler());
            ICommandBus commandBus = new DefaultCommandBus(defaultCommandHandlerFactory);

            object value = commandBus.Dispatch<NewUserCommand>(new NewUserCommand("shiori"));

            Assert.AreEqual(1234, value);
        }

        [TestMethod]
        public void DispatchAsRegistedByInstance()
        {
            DefaultCommandHandlerFactory defaultCommandHandlerFactory = new DefaultCommandHandlerFactory();
            defaultCommandHandlerFactory
                .Register<NewUserCommand>(new NewUserCommandHandler());
            ICommandBus commandBus = new DefaultCommandBus(defaultCommandHandlerFactory);

            object value = commandBus.Dispatch<NewUserCommand>(new NewUserCommand("shiori"));

            Assert.AreEqual(1234, value);
        }

        [TestMethod]
        public void DispatchAsRegistedByGeneric()
        {
            DefaultCommandHandlerFactory defaultCommandHandlerFactory = new DefaultCommandHandlerFactory();
            defaultCommandHandlerFactory
                .Register<NewUserCommand, NewUserCommandHandler>();
            ICommandBus commandBus = new DefaultCommandBus(defaultCommandHandlerFactory);

            object value = commandBus.Dispatch<NewUserCommand>(new NewUserCommand("shiori"));

            Assert.AreEqual(1234, value);
        }

        [TestMethod]
        public void BuildFromAppConfig()
        {
            ConfigurationCommandHandlerFactory factory = new ConfigurationCommandHandlerFactory();
            ICommandBus commandBus = new DefaultCommandBus(factory);
            int value = commandBus.Dispatch<NewUserCommand, int>(new NewUserCommand("shiori"));

            Assert.AreEqual(1234, value);
        }

        [TestMethod]
        public void DispatchInterfaceCommand()
        {
            DefaultCommandHandlerFactory f = new DefaultCommandHandlerFactory();
            f.Register<IInterfaceCommand>(() => new InterfaceCommandHandler());

            ICommandBus bus = new DefaultCommandBus(f);
            var cmd = new MyCommand("Felix");
            bus.Dispatch(cmd);

            Assert.AreEqual("Hello : Felix", cmd.Text);
        }

        private class MyCommand : IInterfaceCommand
        {
            public string Name { get; private set; }

            public string Text { get; set; }
            public MyCommand(string name)
            {
                this.Name = name;
            }
        }
    }
}