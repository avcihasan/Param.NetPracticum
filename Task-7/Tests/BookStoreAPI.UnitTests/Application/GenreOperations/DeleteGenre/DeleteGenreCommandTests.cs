using BookStoreAPI.API.Application.GenreOperations.DeleteGenre;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using Xunit;

namespace GenreStoreAPI.UnitTests.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyNotFoundGenre_InvalidOperationException_ShouldBeReturn()
        {

            DeleteGenreCommand deleteGenreCommand = new(_context);
            deleteGenreCommand.GenreId = 0;

            FluentActions.Invoking(() => deleteGenreCommand.Handle())
               .Should()
               .Throw<InvalidOperationException>()
               .And
               .Message
               .Should()
               .Be("Silinecek tür bulunamadı");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeDeleted()
        {
            Genre genre = new() { IsActive=true,Name="test deneme"};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            DeleteGenreCommand deleteGenreCommand = new(_context);
            deleteGenreCommand.GenreId = genre.Id;



            FluentActions.Invoking(() => deleteGenreCommand.Handle()).Invoke();


            genre = _context.Genres.FirstOrDefault(x => x.Id == genre.Id);

            genre.Should().BeNull();


        }
    }
}
