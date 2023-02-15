using BookStoreAPI.API.Application.BookOperations.CreateBook;
using FluentValidation;

namespace BookStoreAPI.API.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {

        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Genre.Name).MinimumLength(4).NotEmpty();

        }
    }
}
