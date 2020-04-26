using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Reface.CommandBus.Tests
{

    public interface IArgs
    { }

    public interface IArgsHandler { }

    public interface IArgsHandler<TArgs> : IArgsHandler
        where TArgs : IArgs
    {
        void Handle(TArgs args);
    }

    public interface INameArgs : IArgs
    {
        string Name { get; }
        string NameResult { set; }
    }

    public interface IIdArgs : IArgs
    {
        int Id { get; }
        int IdResult { set; }
    }

    public class NameHandler : IArgsHandler<INameArgs>
    {
        public void Handle(INameArgs args)
        {
            args.NameResult = string.Format("Result{0}", args.Name);
        }
    }

    public class IdHandler : IArgsHandler<IIdArgs>
    {
        public void Handle(IIdArgs args)
        {
            args.IdResult = args.Id + 1;
        }
    }

    public class MyArgs : INameArgs, IIdArgs
    {
        public int Id { get; set; }

        public int IdResult { get; set; }

        public string Name { get; set; }

        public string NameResult { get; set; }
    }


    [TestClass]
    public class TiggerModeTests
    {

        [TestMethod]
        public void Test()
        {
            var args = new MyArgs() { Id = 1, Name = "Felix" };
            Do(args);
            Assert.AreEqual("ResultFelix", args.NameResult);
            Assert.AreEqual(2, args.IdResult);
        }

        private void Do<TArgs>(TArgs args) where TArgs : IArgs
        {
            List<Action> actions = new List<Action>();
            actions.Add(() => ExecHandlerByEmit(new IdHandler(), args));
            actions.Add(() => ExecHandlerByEmit(new NameHandler(), args));
            foreach (var action in actions)
                action();

        }

        private void ExecHandlerByEmit(IArgsHandler handler, IArgs args)
        {
            Type argType = handler.GetType().GetInterfaces()
                .FirstOrDefault(x => x.IsGenericType)
                .GetGenericArguments()[0];
            DynamicMethod dynamicMethod = new DynamicMethod("TriggerMethod", null, new Type[] { typeof(IArgsHandler), typeof(IArgs) });
            var il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, handler.GetType());
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Castclass, argType);
            il.Emit(OpCodes.Callvirt, handler.GetType().GetMethod("Handle"));
            il.Emit(OpCodes.Ret);
            var act = (Action<IArgsHandler, IArgs>)dynamicMethod.CreateDelegate(typeof(Action<IArgsHandler, IArgs>));
            act(handler, args);
        }

        private void ExecHandle(IArgsHandler handler, IArgs args)
        {
            handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { args });
        }
    }
}
