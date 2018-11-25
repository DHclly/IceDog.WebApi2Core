# IceDog.WebApi2Core

## 项目介绍
对于 .net core 中 web api2项目的测试

## IceDog.WebApi2Core.ConventionalRoute

通过这篇文章(https://docs.microsoft.com/zh-cn/aspnet/core/web-api/?view=aspnetcore-2.1)可以知道，在 .net core 的 webapi2 
中，必须使用特性路由，而且在app.UseMvc()和 app.UseMvcWithDefaultRoute中声名的路由不会在webappi项目中起作用。因此这个项目的作用是通过特性路由实现传统路由（controller/action）的使用。