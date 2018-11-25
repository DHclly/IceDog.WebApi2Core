using System.Collections.Generic;
using System.Threading.Tasks;
using IceDog.WebApi2Core.DataAccess.Models;
using IceDog.WebApi2Core.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IceDog.WebApi2Core.ConventionalRoute.Controllers
{
    /// <summary>
    /// 宠物控制器
    /// </summary>
    public class PetsController : BaseController//ControllerBase
    {
        private readonly PetsRepository _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public PetsController(PetsRepository repository)//构造函数依赖注入
        {
            _repository = repository;
        }
        /// <summary>
        /// 获取所有宠物
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetAllAsync()
        {
            return await _repository.GetPetsAsync();
        }
        /// <summary>
        /// 根据id获取宠物信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Pet>> GetByIdAsync(int id)
        {
            var pet = await _repository.GetPetAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }
        /// <summary>
        /// 创建宠物
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(400)]//返回响应码 400
        public async Task<ActionResult<Pet>> CreateAsync(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddPetAsync(pet);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = pet.Id }, pet);
        }
    }
}
