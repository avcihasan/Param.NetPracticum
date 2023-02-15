using AutoMapper;
using BookStoreAPI.API.Application.BookOperations.GetBookById;
using BookStoreAPI.API.Application.GenreOperations.GetGenreById;
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

namespace BookStoreAPI.UnitTests.Application.GenreOperations.GetGenreById
{
    public class GetGenreByIdQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyNotFoundGenre_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreByIdQuery getGenreByIdQuery = new(_context,_mapper);
            getGenreByIdQuery.GenreId = 0;

            FluentActions.Invoking(() => getGenreByIdQuery.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Belirtilen Id'ye sahip tür mevcut değildir.");
        }

        [Fact]
        public void WhenGetGenre_InvalidOperationException_ShouldNotBeReturnError()
        {
            Genre genre = new() { IsActive = true,Name="test deneme" };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            GetGenreByIdQuery getGenreByIdQuery = new(_context, _mapper);
            getGenreByIdQuery.GenreId = genre.Id;
            FluentActions.Invoking(() => getGenreByIdQuery.Handle()).Invoke();


            genre.IsActive.Should().Be(getGenreByIdQuery.Handle().IsActive);
            genre.Name.Should().Be(getGenreByIdQuery.Handle().Name);
           


        }
    }
}
