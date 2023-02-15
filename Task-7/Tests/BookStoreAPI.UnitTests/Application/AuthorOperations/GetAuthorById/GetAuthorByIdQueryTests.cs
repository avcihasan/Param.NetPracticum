using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthorById;
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

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.GetAuthorById
{
    public class GetAuthorByIdQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void xx()
        {
            GetAuthorByIdQuery getAuthorByIdQuery = new(_context, _mapper);
            getAuthorByIdQuery.AuthorId = 0;

            FluentActions.Invoking(() => getAuthorByIdQuery.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir yazar kayıtlı değil");
        }

        [Fact]
        public void zz()
        {
            Author author = new() { Name = "deneme", Surname = "deneme", Birthday = DateTime.Now.AddDays(-50) };
            _context.Authors.Add(author);
            _context.SaveChanges();

            GetAuthorByIdQuery getAuthorByIdQuery = new(_context, _mapper);
            getAuthorByIdQuery.AuthorId = author.Id;

            FluentActions.Invoking(() => getAuthorByIdQuery.Handle()).Invoke();

            getAuthorByIdQuery.Handle().Should().NotBeNull();

            getAuthorByIdQuery.Handle().Name.Should().Be(author.Name);
            getAuthorByIdQuery.Handle().Surname.Should().Be(author.Surname);
            getAuthorByIdQuery.Handle().Birthday.Should().Be(author.Birthday);
        }
    }
}
