using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.CommandBus.IntegrateAutofac.Tests.Commands;

namespace Reface.CommandBus.Tests
{
    [TestClass()]
    public class AutofacCommandHandlerFactoryTests
    {
        [TestMethod()]
        public void Create()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegsiterCommandHandlers(this.GetType().Assembly);
            builder.RegisterType(typeof(AutofacCommandHandlerFactory)).AsImplementedInterfaces();
            builder.RegisterType(typeof(DefaultCommandBus)).AsImplementedInterfaces();
            var container = builder.Build();

            ICommandBus bus = container.Resolve<ICommandBus>();
            ACommand cmd = new ACommand();
            Assert.AreEqual("A", bus.Dispatch<ACommand, string>(cmd));
        }
    }
}