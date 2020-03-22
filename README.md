# Reface.CommandBus

## 1 简介

**Command Bus** 就是命令总线。

**命令总线** 是一种将 **命令** 与 **执行** 分离的设计思想。

### 1.1 举个例子

以创建一个系统用户为示例，普通的代码大致如下 :

```csharp
public class UserController : ControllerBase
{
    // 用户服务，可能通过某些 IOC / DI 注入得到
    private readonly IUserService userService;

    // 为了简化，只以登录名和密码作为参数。
    [HttPost("Create")]
    public Guid Create(string loginName, string password)
    {
        Guid newId = this.userService.Create(new User()
        {
            LoginName = loginName,
            Password = password
        });
        return newId;
    }
}
```

上面的代码已经将 **Controller** 与 **Service的实现** 分离了，
编写者只要通过约定好的 **IUserService** 就可以进行各种操作了。

虽然耦合度已经大幅度降低，
但是依赖存在着 **UserController** 对 **IUserService** 的依赖。

让 **UserController.Create** 只关心对用户的创建，而不关心由哪个 **Service** 创建，可以让耦合度变得更低。

**Command Bus**，这是一个让调用方仅关心命令本身，而不需要关心由谁来处理的结构。
使用 **Command Bus** 后 **Controller** 的代码大体如下

```csharp
// UserController.cs
public class UserController : ControllerBase
{
    // 命令总线，可能通过某些 IOC / DI 注入得到
    private readonly ICommandBus commandBus;

    // 为了简化，只以登录名和密码作为参数。
    [HttPost("Create")]
    public Guid Create(string loginName, string password)
    {
        // 构建一个命令
        CreateUserCommand command = new CreateUserCommand(loginName, password);
        // 将命令交给命令总线，不用关心由谁实现
        Guid newId = this.commandBus.Dispatch<CreateUserCommand, Guid>(command);
        return newId;
    }
}
```

我们可以在一个合适的位置编写一个命令执行类来处理这个指令
```csharp
// Handlers/CreateUserCommandHandler.cs
public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUserService userService;

    public object Handle(CreateUserCommand command)
    {
        return userService.Create(new User()
        {
            LoginName = command.LoginName,
            Password = command.Password
        });
    }
}
```

就像这样，我们把 **执令** 和 **执行分离** 了。
更低的耦合度，会带来更好的维护性。

更多 **命令总线** 的信息，可以点击 [CQRS] 查阅更多文章。

## 2 安装

访问 [nuget] 页面，使用相应的命令行下载最新版。

## 3 使用

### 3.1 定义 Command

*Command* 必须实现 *ICommand* 接口，
该接口目标是一个空接口，没有任何需要实现的内容。


### 3.2 定义 CommandHandler

CommandHandler 必须实现 ICommandHandler&lt;TCommand> 接口，
对实现其 Handle 方法，
Handle 方法可以返回 object ，

在通常情况下，我们不需要对 CommandHandler 的返回类型做抽象，
在特殊的使用场景下，我们可以对 CommandHandler 的返回类型做抽象，一个常见的例子就是 MVC 下的 ActionResult。

> MVC 就是一种 CommandBus 的应用，Http 请求就是 Command, Controller 就是 Handler

### 3.3 创建 CommandHandlerFactory

**CommandHandlerFactory** 是一个注册了所有 **CommandHandler** 组件，它被设计成了允许用户自己开发的模式，只需要实现 **ICommandHandlerFactory** 就可以成为一个 **CommandHandlerFactory**。

目前系统里包含了以下两个 **CommandHandlerFactory**
* *DefaultCommandHandlerFactory*, 手动注册 Handler
* *ConfigurationCommandHandlerFactory*, 通过 App.Config / Web.Config 注册 Handler，如何配置见最后的 《配置文件结构》

```csharp
ICommandHandlerFactory factory = new xxxxxCommandHandlerFactory();
```

### 3.4 构建 CommandBus

```csharp
// DefaultCommandBus 被设计了成了通过构造函数注入工厂的方式
// 你可以使用任何一种 IOC / DI 框架，对其进行自动组装。
ICommandBus commandBus = new DefaultCommandBus(factory);
```

### 3.5 发出命令

```csharp
HelloCommand command = new HelloCommand();

// 只要你所编写的 Handler 能够从 ICommandHandlerFactory 中产出，这里一定会执行到
string result = commandBus.Dispatch<HelloCommand, string>(command);
```

---

# 配置文件结构

## 1 引入 section

放在 configuration / configSections 内

```xml
<section name="commandBus" type="Reface.CommandBus.Configuration.CommandBusSection, Reface.CommandBus"/>
```

## 2 添加 Handler

```xml
<commandBus>
    <handlers>
        <add type="Reface.CommandBus.Tests.CommandHandlers.NewUserCommandHandler, Reface.CommandBus.Tests"></add>
    </handlers>
</commandBus>
```


[CQRS]: https://www.baidu.com/s?ie=UTF-8&wd=CQRS
[nuget]: https://www.nuget.org/packages/Reface.CommandBus/