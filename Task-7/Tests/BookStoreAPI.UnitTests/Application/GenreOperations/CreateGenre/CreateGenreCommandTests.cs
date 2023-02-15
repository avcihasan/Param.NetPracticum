using AutoMapper;
using BookStoreAPI.API.Application.BookOperations.CreateBook;
using BookStoreAPI.API.Application.GenreOperations.CreateGenre;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            Genre genre = new() { IsActive = true, Name = "test deneme" };
            _context.Genres.Add(genre);
            _context.SaveChanges();
            CreateGenreCommand createGenreCommand = new(_context, _mapper);
            createGenreCommand.Genre = new() { IsActive = genre.IsActive, Name = genre.Name };
            FluentActions.Invoking(() => createGenreCommand.Handle())
                .Should()
                .Throw<InvalidOperationException>()
                .And
                .Message
                .Should()
                .Be("Tür zaten mevcut.");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            CreateGenreCommand createGenreCommand = new(_context, _mapper);
            createGenreCommand.Genre = new() { IsActive = true, Name = "test deneme1" };
            FluentActions.Invoking(() => createGenreCommand.Handle()).Invoke();
            Genre genre = _context.Genres.FirstOrDefault(x => x.Name == createGenreCommand.Genre.Name);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(createGenreCommand.Genre.Name);
        }
    }
}
