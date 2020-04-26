using System;
using Reface.CommandBus.Core;

namespace Reface.CommandBus
{
    /// <summary>
    /// 命令处理器信息
    /// </summary>
    public class CommandHandlerInfo
    {
        /// <summary>
        /// 所能处理的命令类型
        /// </summary>
        public Type CommandType { get; private set; }

        /// <summary>
        /// 命令处理器创建器
        /// </summary>
        public Func<ICommandHandler> Creator { get; private set; }

        public CommandHandlerInfo(Type commandType, Func<ICommandHandler> creator)
        {
            CommandType = commandType;
            Creator = creator;
        }
    }
}
