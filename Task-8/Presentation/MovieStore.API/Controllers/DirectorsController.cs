using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.DTOs.DirectorDTOs;
using MovieStore.Application.Services;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _service;

        public DirectorsController(IDirectorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorDto createDirectorDto)
        {
            return Ok(await _service.CreateDirectorAsync(createDirectorDto));
        }
        [HttpDelete("{directorId}")]
        public async Task<IActionResult> DeleteDirector([FromRoute] int directorId)
        {
            await _service.RemoveAsync(directorId);
            return Ok();
        }
        [HttpPut("{directorId}")]
        public async Task<IActionResult> UpdateDirector([FromRoute] int directorId, [FromBody] UpdateDirectorDto updateDirectorDto)
        {
            return Ok(await _service.UpdateDirectorAsync(directorId, updateDirectorDto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDirectors()
        {
            return Ok(await _service.GetAllDirectorsAsync());
        }
    }
}
