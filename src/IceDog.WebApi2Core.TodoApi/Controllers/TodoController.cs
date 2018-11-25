using IceDog.WebApi2Core.TodoApi.Context;
using IceDog.WebApi2Core.TodoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IceDog.WebApi2Core.TodoApi.Controllers
{
    //[Route("api/[controller]")]//和[Route("api/TodoController")]效果相同，都是去掉controller后缀，
    //替换为控制器名todo，ASP.NET Core 路由不区分大小写
    //[Produces("application/json")]//声明控制器的操作支持application/json 的响应内容类型

    /// <summary>
    /// Todo控制器
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TodoController : Controller
    {
        private static bool isFirst = true;
        private readonly TodoContext _context;
        /// <summary>
        /// 控制器的构造函数
        /// </summary>
        /// <param name="context"></param>
        public TodoController(TodoContext context)
        {
            _context = context;

            if (isFirst)
            {
                isFirst = false;
                _context.TodoItems.AddRange(
                    new TodoItem { Name = "起床吃饭", IsComplete = true },
                    new TodoItem { Name = "做一个小时锻炼", IsComplete = false },
                    new TodoItem { Name = "去逛街", IsComplete = false },
                    new TodoItem { Name = "做家务", IsComplete = true },
                    new TodoItem { Name = "工作2小时", IsComplete = false });
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// 获取所有对象
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }
        /// <summary>
        /// 通过id获取单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// 创建一个对象。
        /// </summary>
        /// <remarks>
        /// 请求示例:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item">TodoItem对象</param>
        /// <returns>返回一个新建的TodoItem对象</returns>
        /// <response code="201">返回一个新建的TodoItem对象</response>
        /// <response code="400">如果item为null</response>            
        [HttpPost]
        [ProducesResponseType(typeof(TodoItem), 201)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
        //httpPut整个对象更新，httpPatch单个属性更新

        /// <summary>
        /// 根据id更新一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }
        /// <summary>
        /// 根据id删除一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}