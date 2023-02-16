using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Application.Services;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] CreateActorDto createActorDto)
        {
            return Ok(await _service.CreateActorAsync(createActorDto));
        }
        [HttpDelete("{actorId}")]
        public async Task<IActionResult> DeleteActor([FromRoute] int actorId)
        {
            await _service.RemoveAsync(actorId);
            return Ok();
        }
        [HttpPut("{actorId}")]
        public async Task<IActionResult> UpdateActor([FromRoute] int actorId, [FromBody] UpdateActorDto updateActorDto)
        {
            return Ok(await _service.UpdateActorAsync(actorId, updateActorDto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            return Ok(await _service.GetAllActorsAsync());
        }
    }
}
