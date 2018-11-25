using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IceDog.WebApi2Core.ConventionalRoute.Controllers
{
    [Route("api/[controller]/[action]")]//特性路由
    [ApiController]//表名是webapi 控制器，不是mvc控制器
    [Produces("application/json")]//希望返回的ContentType类型
    public class BaseController : ControllerBase
    {

    }
}