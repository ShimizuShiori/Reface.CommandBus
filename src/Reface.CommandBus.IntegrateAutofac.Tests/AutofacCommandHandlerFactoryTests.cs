using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.CommandBus.IntegrateAutofac.Tests.Commands;

namespace Reface.CommandBus.Tests
{
    public class MyCommand : ACommand, BCommand
    {
        public string BResult { get; set; }
        public string AResult { get; set; }
    }

    [TestClass()]
    public class AutofacCommandHandlerFactoryTests
    {
        [TestMethod()]
        public void Create()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder
                .RegisterCommandBusComponents()
                .RegsiterCommandHandlers(this.GetType().Assembly);
            var container = builder.Build();

            ICommandBus bus = container.Resolve<ICommandBus>();
            MyCommand cmd = new MyCommand();
            bus.Dispatch(cmd);
            Assert.AreEqual("A", cmd.AResult);
            Assert.AreEqual("B", cmd.BResult);
        }
    }
}