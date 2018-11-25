using System.Collections.Generic;
using System.Threading.Tasks;
using IceDog.WebApi2Core.DataAccess.Models;
using IceDog.WebApi2Core.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IceDog.WebApi2Core.ConventionalRoute.Controllers
{
    [Produces("application/json")]//希望返回的ContentType类型
    //[Route("api/[controller]")]//特性路由
    //[ApiController]//表明这是web api controller
    public class PetsController : BaseController//ControllerBase
    {
        private readonly PetsRepository _repository;

        public PetsController(PetsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetAllAsync()
        {
            return await _repository.GetPetsAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Pet>> GetByIdAsync(int id)
        {
            var pet = await _repository.GetPetAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        [ProducesResponseType(400)]
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
