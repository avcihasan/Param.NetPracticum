using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Application.Services;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody]CreateMovieDto createMovieDto)
        {
            return Ok(await _service.CreateMovieAsync(createMovieDto));
        }
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int movieId)
        {
            await _service.RemoveAsync(movieId);
            return Ok();
        }
        [HttpPut("{movieId}")]
        public async Task<IActionResult> UpdateMovie([FromRoute]int movieId,[FromBody]UpdateMovieDto updateMovieDto)
        {
            return Ok(await _service.UpdateMovieAsync(movieId, updateMovieDto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMoives()
        {  
            return Ok(await _service.GetAllMoviesAsync());
        }
    }
}
