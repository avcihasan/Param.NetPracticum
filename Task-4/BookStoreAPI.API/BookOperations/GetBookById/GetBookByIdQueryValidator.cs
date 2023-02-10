using FluentValidation;

namespace BookStoreAPI.API.BookOperations.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery.GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
