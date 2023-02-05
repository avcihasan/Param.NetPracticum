using BookStoreAPI.Application.DTOs.AuthorDTOs;
using BookStoreAPI.Application.DTOs.GenreDTOs;
using BookStoreAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.API.Controllers
{
    public class GenresController : CustomBaseController
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        //genre temek crud işlemleri
        [HttpGet]
        public async Task<IActionResult> Get()
            => CreateActionResult(await _genreService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
            => CreateActionResult(await _genreService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SetGenreDto setGenreDto)
            => CreateActionResult(await _genreService.AddGenreAsync(setGenreDto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SetGenreDto setGenreDto)
            => CreateActionResult(await _genreService.UpdateGenreAsync(id, setGenreDto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
            => CreateActionResult(await _genreService.RemoveAsync(id));
    }
}
