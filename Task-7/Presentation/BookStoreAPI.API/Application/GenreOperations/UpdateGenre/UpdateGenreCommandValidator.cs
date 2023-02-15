using FluentValidation;

namespace BookStoreAPI.API.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Genre.Name).MinimumLength(4)
       .When(x => x.Genre.Name != string.Empty);

            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
