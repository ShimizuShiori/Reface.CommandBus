using System;
using System.Collections.Generic;
using Reface.CommandBus.Core;

namespace Reface.CommandBus
{
    /// <summary>
    /// 默认的处理器工厂
    /// </summary>
    public class DefaultCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly List<CommandHandlerInfo> creators;

        public DefaultCommandHandlerFactory()
        {
            this.creators = new List<CommandHandlerInfo>();
        }

        /// <summary>
        /// 注册一个命令处理器
        /// </summary>
        /// <typeparam name="TCommand">所能处理的命令类型</typeparam>
        /// <param name="creator"></param>
        /// <returns></returns>
        public DefaultCommandHandlerFactory Register<TCommand>(Func<ICommandHandler> creator)
            where TCommand : ICommand
        {

            this.creators.Add(new CommandHandlerInfo(typeof(TCommand), creator));
            return this;
        }

        public IEnumerable<ICommandHandler> GetHandlers(Type commandType)
        {
            List<ICommandHandler> result = new List<ICommandHandler>();
            foreach (var creator in creators)
            {
                if (!creator.CommandType.IsAssignableFrom(commandType)) continue;
                result.Add(creator.Creator());
            }
            return result;
        }
    }
}
