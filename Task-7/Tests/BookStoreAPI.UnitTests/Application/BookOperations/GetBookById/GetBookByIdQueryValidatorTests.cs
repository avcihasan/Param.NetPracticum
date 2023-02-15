using BookStoreAPI.API.Application.BookOperations.CreateBook;
using BookStoreAPI.API.Application.BookOperations.GetBookById;
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
    public class GetBookByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void xxxx(int id)
        {
            GetBookByIdQuery getBookByIdQuery = new(null, null);
            getBookByIdQuery.BookId = id;


            GetBookByIdQueryValidator validator = new();
            var result = validator.Validate(getBookByIdQuery);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void zzzz()
        {
            GetBookByIdQuery getBookByIdQuery = new(null, null);
            getBookByIdQuery.BookId = 10;


            GetBookByIdQueryValidator validator = new();
            var result = validator.Validate(getBookByIdQuery);

            result.Errors.Count.Should().Be(0);
        }
    }
}
