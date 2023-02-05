using BookStoreAPI.API.CustomAttributes;
using BookStoreAPI.Application.DTOs.AuthorDTOs;
using BookStoreAPI.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.API.Controllers
{
  
    public class AuthorsController : CustomBaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        //author temek crud işlemleri

       
        [HttpGet]
        public async Task<IActionResult> Get()
            => CreateActionResult(await _authorService.GetAllAsync());

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
            => CreateActionResult(await _authorService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SetAuthorDto setAuthorDto) 
            => CreateActionResult(await _authorService.AddAuthorAsync(setAuthorDto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] SetAuthorDto setAuthorDto)
            => CreateActionResult(await _authorService.UpdateAuthorAsync(id,setAuthorDto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
            => CreateActionResult(await _authorService.RemoveAsync(id));

    }
}
