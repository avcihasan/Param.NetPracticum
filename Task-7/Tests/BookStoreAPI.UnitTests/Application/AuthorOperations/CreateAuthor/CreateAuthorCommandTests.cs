using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.CreateAuthor;
using BookStoreAPI.API.Application.BookOperations.CreateBook;
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

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void WhenAlreadyExistAuthorNameSurnameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            Author author = new() { Name="deneme test",Surname= "deneme test" ,Birthday=DateTime.Now.AddDays(-10)};
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand createAuthorCommand = new(_context, _mapper);
            createAuthorCommand.Author= new() { Name = author.Name, Surname = author.Surname ,Birthday=author.Birthday};


            FluentActions.Invoking(() => createAuthorCommand.Handle())
                .Should()
                .Throw<InvalidOperationException>()
                .And
                .Message
                .Should()
                .Be("Yazar zaten mevcut.");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {


            CreateAuthorCommand createAuthorCommand = new(_context, _mapper);
            createAuthorCommand.Author = new() {Name="1deneme",Surname="1deneme",Birthday=DateTime.Now.AddDays(-50)};


            FluentActions.Invoking(() => createAuthorCommand.Handle()).Invoke();


            Author author = _context.Authors.FirstOrDefault(x => x.Name == createAuthorCommand.Author.Name && x.Surname == createAuthorCommand.Author.Surname);

            author.Should().NotBeNull();
            author.Name.Should().Be(createAuthorCommand.Author.Name);
            author.Surname.Should().Be(createAuthorCommand.Author.Surname);


        }
    }
}
