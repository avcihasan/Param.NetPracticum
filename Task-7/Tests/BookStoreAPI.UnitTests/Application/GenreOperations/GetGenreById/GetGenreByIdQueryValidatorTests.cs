using BookStoreAPI.API.Application.BookOperations.GetBookById;
using BookStoreAPI.API.Application.GenreOperations.GetGenreById;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.GenreOperations.GetGenreById
{
    public class GetGenreByIdQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void xxxx(int id)
        {
            GetGenreByIdQuery getGenreByIdQuery = new(null, null);
            getGenreByIdQuery.GenreId = id;


            GetGenreByIdQueryValidator validator = new();
            var result = validator.Validate(getGenreByIdQuery);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void zzzz()
        {
            GetGenreByIdQuery getGenreByIdQuery = new(null, null);
            getGenreByIdQuery.GenreId = 10;


            GetGenreByIdQueryValidator validator = new();
            var result = validator.Validate(getGenreByIdQuery);

            result.Errors.Count.Should().Be(0);
        }
    }
}
