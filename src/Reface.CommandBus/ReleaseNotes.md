# Release Notes

## 1.0.0

* 自定义 *Command*
* 自定义 *CommandHandler*
* 向 *CommandHandlerFactory* 注册 *CommandHandler*
    * 通过 *Code* 的方式注册
    * 通过 *.config* 文件的方式注册
* 允许用户开发自定义的 *CommandHandlerFactory*
* 实现了 不需要关心 *CommandHandler* 的 *CommandBus.Dispatch* 方法