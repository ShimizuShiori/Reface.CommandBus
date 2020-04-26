using System;
using System.Collections.Generic;
using Reface.CommandBus.Core;

namespace Reface.CommandBus
{
    /// <summary>
    /// 命令处理器工厂
    /// </summary>
    public interface ICommandHandlerFactory
    {
        /// <summary>
        /// 根据指定的命令类型，获取所有可以处理的处理器
        /// </summary>
        /// <param name="commandType"></param>
        /// <returns></returns>
        IEnumerable<ICommandHandler> GetHandlers(Type commandType);
    }
}
