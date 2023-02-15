using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthorById;
using BookStoreAPI.API.Application.BookOperations.GetBookById;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.GetAuthorById
{
    public class GetAuthorByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void xxxx(int id)
        {
            GetAuthorByIdQuery getAuthorByIdQuery = new(null, null);
            getAuthorByIdQuery.AuthorId = id;


            GetAuthorByIdQueryValidator validator = new();
            var result = validator.Validate(getAuthorByIdQuery);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void zzzz()
        {
            GetAuthorByIdQuery getAuthorByIdQuery = new(null, null);
            getAuthorByIdQuery.AuthorId = 10;


            GetAuthorByIdQueryValidator validator = new();
            var result = validator.Validate(getAuthorByIdQuery);

            result.Errors.Count.Should().Be(0);
        }


       

    }
}
