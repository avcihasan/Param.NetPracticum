using AutoMapper;
using BookStoreAPI.API.Application.BookOperations.GetBookById;
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

namespace BookStoreAPI.UnitTests.Application.BookOperations.GetBookById
{
    public class GetBookByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;
        public GetBookByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper=testFixture.Mapper;
        }

        [Fact]
        public void xxx()
        {
            GetBookByIdQuery getBookByIdQuery = new(_context,_mapper);
            getBookByIdQuery.BookId = 0;
            FluentActions.Invoking(() => getBookByIdQuery.Handle()).Should()
               .Throw<InvalidOperationException>()
               .And
               .Message
               .Should()
               .Be("Belirtilen Id'ye sahip kitap mevcut değildir.");
        }

        [Fact]
        public void yyy()
        {
            Book book = new() { Title = "deneme test", AuthorId = 1, GenreId = 1, IsActive = false, PageCount = 10, PublishDate = DateTime.Now.AddMinutes(-50) };
            _context.Books.Add(book);
            _context.SaveChanges();

            GetBookByIdQuery getBookByIdQuery = new(_context, _mapper);
            getBookByIdQuery.BookId = book.Id;
            FluentActions.Invoking(() => getBookByIdQuery.Handle()).Should()
               .Throw<InvalidOperationException>()
               .And
               .Message
               .Should()
               .Be("Belirtilen Id'ye sahip kitap aktif değildir.");
        }

        [Fact]
        public void zzzz()
        {
            Book book = new() { Title = "deneme test", AuthorId = 1, GenreId = 1, IsActive = true, PageCount = 10, PublishDate = DateTime.Now.AddMinutes(-50) };
            _context.Books.Add(book);
            _context.SaveChanges();

            GetBookByIdQuery getBookByIdQuery = new(_context, _mapper);
            getBookByIdQuery.BookId = book.Id;
            FluentActions.Invoking(() => getBookByIdQuery.Handle()).Invoke();


            book.PageCount.Should().Be(getBookByIdQuery.Handle().PageCount);
            book.Title.Should().Be(getBookByIdQuery.Handle().Title);
            book.PublishDate.ToString().Should().Be(getBookByIdQuery.Handle().PublishDate);



        }
    }
}
