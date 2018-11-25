using IceDog.WebApi2Core.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace IceDog.WebApi2Core.ConventionalRoute.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    public class TestController : BaseController
    {
        // Don't do this. All of the following actions result in an exception.
        [HttpPost]
        public IActionResult Action1(Product product,  Order order) => null;

        [HttpPost]
        public IActionResult Action2(Product product, [FromBody] Order order) => null;

        [HttpPost]
        public IActionResult Action3([FromBody] Product product, [FromBody] Order order) => null;
    }
}