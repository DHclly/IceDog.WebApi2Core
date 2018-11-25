using IceDog.WebApi2Core.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace IceDog.WebApi2Core.ConventionalRoute.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TestController : BaseController
    {
        #region snippet_ActionsCausingExceptions
        // Don't do this. All of the following actions result in an exception.
        //不要这样做，下面这几种情况都会报错

        //默认推断使用[FromBody]，但是使用FromBody修饰的只能是一个类型对象，下面这是两个，错了
        //[HttpPost]
        //public IActionResult Action1(Product product,  Order order) => null;

        //只能有一个类型对象，错了
        //[HttpPost]
        //public IActionResult Action2(Product product, [FromBody] Order order) => null;

        //只能有一个类型对象，错了
        //[HttpPost]
        //public IActionResult Action3([FromBody] Product product, [FromBody] Order order) => null;
        #endregion

        //这是正确的
        [HttpPost]
        public IActionResult Action4([FromBody] Product product) => null;
    }
}