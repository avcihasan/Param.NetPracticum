using AutoMapper;
using BookStoreAPI.API.Application.GenreOperations.CreateGenre;
using BookStoreAPI.API.Application.GenreOperations.DeleteGenre;
using BookStoreAPI.API.Application.GenreOperations.GetGenreById;
using BookStoreAPI.API.Application.GenreOperations.GetGenres;
using BookStoreAPI.API.Application.GenreOperations.UpdateGenre;
using BookStoreAPI.API.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static BookStoreAPI.API.Application.GenreOperations.CreateGenre.CreateGenreCommand;
using static BookStoreAPI.API.Application.GenreOperations.UpdateGenre.UpdateGenreCommand;

namespace BookStoreAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(BookStoreAPIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery getGenresQuery = new(_context, _mapper);  
            return Ok(getGenresQuery.Handle());
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetGenreByIdQuery getGenreByIdQuery = new(_context, _mapper);
            getGenreByIdQuery.GenreId = id;
            GetGenreByIdQueryValidator validator = new();
            validator.ValidateAndThrow(getGenreByIdQuery);
            return Ok(getGenreByIdQuery.Handle());
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand createGenreCommand = new(_context, _mapper);
            createGenreCommand.Genre = newGenre;
            CreateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(createGenreCommand);
            createGenreCommand.Handle();
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand updateGenreCommand = new(_context);
            updateGenreCommand.GenreId = id;
            updateGenreCommand.Genre = updateGenre;
            UpdateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(updateGenreCommand);
            updateGenreCommand.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand deleteGenreCommand = new(_context);
            deleteGenreCommand.GenreId = id;
            DeleteGenreCommandValidator validator = new();
            validator.ValidateAndThrow(deleteGenreCommand);
            deleteGenreCommand.Handle();
            return Ok();
        }
    }
}
