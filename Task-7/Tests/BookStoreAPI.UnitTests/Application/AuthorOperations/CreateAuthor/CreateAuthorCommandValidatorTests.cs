using BookStoreAPI.API.Application.AuthorOperations.CreateAuthor;
using BookStoreAPI.API.Application.BookOperations.CreateBook;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("deneme","")]
        [InlineData("", "deneme")]
        [InlineData("","")]
        public void xxxx(string name,string surname)
        {
            CreateAuthorCommand createAuthorCommand = new(null,null);
            createAuthorCommand.Author = new() { Birthday = DateTime.Now.AddDays(-50), Name = name, Surname = surname };

            CreateAuthorCommandValidator validator = new();
           var result= validator.Validate(createAuthorCommand);
            result.Errors.Count.Should().BeGreaterThan(0);

        }



        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {

            CreateAuthorCommand createAuthorCommand = new(null, null);

            createAuthorCommand.Author = new() { Birthday = DateTime.Now, Name = "deneme", Surname = "deneme" };
            CreateAuthorCommandValidator validator = new();
            var result = validator.Validate(createAuthorCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {

            CreateAuthorCommand createAuthorCommand = new(null, null);
            createAuthorCommand.Author = new() { Birthday = DateTime.Now.AddHours(-50), Name = "deneme", Surname = "deneme" };
            CreateAuthorCommandValidator validator = new();
            var result = validator.Validate(createAuthorCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
