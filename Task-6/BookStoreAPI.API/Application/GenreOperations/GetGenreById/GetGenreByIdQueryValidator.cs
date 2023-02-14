using FluentValidation;

namespace BookStoreAPI.API.Application.GenreOperations.GetGenreById
{
    public class GetGenreByIdQueryValidator:AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
