using FluentValidation;

namespace BookStoreAPI.API.Application.AuthorOperations.GetAuthorById
{
    public class GetAuthorByIdQueryValidator:AbstractValidator<GetAuthorByIdQuery>  
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);

        }
    }
}
