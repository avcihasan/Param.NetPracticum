using FluentValidation;

namespace BookStoreAPI.API.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Genre.Name).MaximumLength(4)
       .When(x => x.Genre.Name != string.Empty);
        }
    }
}
