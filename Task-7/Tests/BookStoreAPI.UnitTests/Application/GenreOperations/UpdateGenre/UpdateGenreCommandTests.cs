using BookStoreAPI.API.Application.GenreOperations.UpdateGenre;
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

namespace BookStoreAPI.UnitTests.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateGenreCommand updateGenreCommand = new(_context);
            updateGenreCommand.GenreId = 0;

            FluentActions.Invoking(() => updateGenreCommand.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Belirtilen Id'ye sahip tür mevcut değildir.");
        }


        [Fact]
        public void WhenGivenGenreIdIsinDB_InvalidOperationException_ShouldNotBeReturnError()
        {
            Genre genre = new() { Name = "test deneme", IsActive = true };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            UpdateGenreCommand updateGenreCommand = new(_context);
            updateGenreCommand.GenreId = genre.Id;
            updateGenreCommand.Genre = new() { Name = genre.Name, IsActive = genre.IsActive };

            FluentActions.Invoking(() => updateGenreCommand.Handle()).Invoke();

            genre.Name.Should().Be(updateGenreCommand.Genre.Name);
            genre.IsActive.Should().Be(updateGenreCommand.Genre.IsActive);

        }
    }
}
