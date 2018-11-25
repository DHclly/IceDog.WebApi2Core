# IceDog.WebApi2Core

## 项目介绍
对于 .net core 中 web api2项目的测试，默认都是以2.1为基准

## IceDog.WebApi2Core.ConventionalRoute

通过特性路由实现传统路由的效果。

通过这篇文章(https://docs.microsoft.com/zh-cn/aspnet/core/web-api/?view=aspnetcore-2.1)可以知道，在 .net core 的 webapi2 
中，必须使用特性路由，而且在app.UseMvc()和 app.UseMvcWithDefaultRoute中声名的路由不会在webappi项目中起作用。因此这个项目的作用是通过特性路由实现传统路由（controller/action）的使用。

## IceDog.WebApi2Core.DataAccess

使用内存数据库的数据访问层，通过 EF Core 和仓储模式的方式构建，作为`IceDog.WebApi2Core.ConventionalRoute`和`IceDog.WebApi2Core.RestfulApi`的数据源

## IceDog.WebApi2Core.RestfulApi

Restful Api 风格的请求方式，内容和IceDog.WebApi2Core.ConventionalRoute一样，主要是路由方式不同，做个对比。

## IceDog.WebApi2Core.TodoApi

官方教程示例， 一个 Todo App。