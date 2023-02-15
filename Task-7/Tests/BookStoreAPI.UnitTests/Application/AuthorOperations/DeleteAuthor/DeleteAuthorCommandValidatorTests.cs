using BookStoreAPI.API.Application.AuthorOperations.DeleteAuthor;
using BookStoreAPI.API.Application.BookOperations.DeleteBook;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidAuthorIdisGiven_Validator_ShouldBeReturnError(int id)
        {
            DeleteAuthorCommand deleteAuthorCommand = new(null);
            deleteAuthorCommand.AuthorId = id;

            DeleteAuthorCommandValidator validator = new();
            var result = validator.Validate(deleteAuthorCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidAuthorIdisGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand deleteBookCommand = new(null);
            deleteBookCommand.BookId = 1;

            DeleteBookCommandValidator validator = new();
            var result = validator.Validate(deleteBookCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
