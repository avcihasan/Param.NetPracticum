using AutoMapper;
using BookStoreAPI.API.BookOperations.CreateBook;
using BookStoreAPI.API.BookOperations.DeleteBook;
using BookStoreAPI.API.BookOperations.GetBooks;
using BookStoreAPI.API.BookOperations.GetBookByIdQuery;
using BookStoreAPI.API.BookOperations.UpdateBook;
using BookStoreAPI.API.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStoreAPI.API.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreAPI.API.BookOperations.GetBookByIdQuery.GetBooksByIdQuery;
using static BookStoreAPI.API.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStoreAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreAPIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BooksViewIdModel result;
            try
            {
                GetBooksByIdQuery query = new GetBooksByIdQuery(_context, _mapper);
                query.BookId = id;
                result = query.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }

        [HttpDelete(("{id}"))]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
