using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookRepository.GetAll().ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            return book == null ? NotFound(): Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            _bookRepository.Update(book);
            await _bookRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book==null)
            {
                return BadRequest();
            }
            _bookRepository.Remove(book);
            await _bookRepository.SaveAsync();
            return Ok();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<Book> patchDocument)
        {
            Book book =await _bookRepository.GetByIdAsync(id);
            patchDocument.ApplyTo(book, ModelState);
            await _bookRepository.SaveAsync();
            return Ok(book);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetToAscending([FromQuery] string propertyName)
        {
            return Ok(await _bookRepository.GetAllByPropertyNameToAscending(propertyName).ToListAsync());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetToDescending([FromQuery] string propertyName)
        {
            return Ok(await _bookRepository.GetAllByPropertyNameToDescending(propertyName).ToListAsync());
        }
    }
}
