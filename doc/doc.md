# Web Api 2.1

- 使用 ASP.NET Core 构建 Web API  https://docs.microsoft.com/zh-cn/aspnet/core/web-api/?view=aspnetcore-2.1
- 使用 ASP.NET Core 和 Visual Studio 创建 Web API https://docs.microsoft.com/zh-cn/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1

下面是一些摘要

## 绑定参数源

| 特性               | 绑定源                     |
| ------------------ | -------------------------- |
| **[FromBody]**     | 请求正文                   |
| **[FromForm]**     | 请求正文中的表单数据       |
| **[FromHeader]**   | 请求标头                   |
| **[FromQuery]**    | 请求查询字符串参数         |
| **[FromRoute]**    | 当前请求中的路由数据       |
| **[FromServices]** | 作为操作参数插入的请求服务 |

 **警告**

当值可能包含 `%2f`（即 `/`）时，请勿使用 `[FromRoute]`。 `%2f` 不会转换为 `/`（非转义形式）。 如果值可能包含 `%2f`，则使用 `[FromQuery]`。

不能通过 [UseMvc](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.mvcapplicationbuilderextensions.usemvc) 中定义的[传统路由](https://docs.microsoft.com/zh-cn/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.1#conventional-routing)或通过 `Startup.Configure` 中的 [UseMvcWithDefaultRoute](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.mvcapplicationbuilderextensions.usemvcwithdefaultroute) 访问操作。