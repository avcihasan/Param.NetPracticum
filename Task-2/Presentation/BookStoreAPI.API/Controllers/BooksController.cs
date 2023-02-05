using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.BookDTOs;
using BookStoreAPI.Application.Services;
using BookStoreAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStoreAPI.API.Controllers
{
    
    public class BooksController : CustomBaseController
    {
        private readonly IBookService _bookService;
        //bookservice injekt edilme işlemi
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => CreateActionResult(await _bookService.GetAllBooksWithAllPropertiesAsync());
        // Tek satırlık return işlemi olduğu için süslü parantezler içine girip return yapmak ile => kullanabiliriz


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
            => CreateActionResult(await _bookService.GetBookByIdWithAllPropertiesAsync(id));


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SetBookDto setBook)
            => CreateActionResult(await _bookService.AddBookAsync(setBook));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] SetBookDto setBookDto)
            => CreateActionResult(await _bookService.UpdateBookAsync(id, setBookDto));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute]int id)
            => CreateActionResult(await _bookService.RemoveAsync(id));


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument<Book> patchDocument)
        {
            patchDocument.ApplyTo((await _bookService.GetByIdAsync(id)).Data, ModelState);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetToAscending([FromQuery] string propertyName)
            => CreateActionResult(await _bookService.GetAllByPropertyNameToAscendingAsync(propertyName));


        [HttpGet("[action]")]
        public async Task<IActionResult> GetToDescending([FromQuery] string propertyName)
            => CreateActionResult(await _bookService.GetAllByPropertyNameToDescendingAsync(propertyName));
    }
}
