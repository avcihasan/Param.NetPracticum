    using FluentValidation;

namespace BookStoreAPI.API.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>    
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Author.Name).MinimumLength(4)
       .When(x => x.Author.Name != string.Empty);

            RuleFor(x => x.Author.Surname).MinimumLength(4)
            .When(x => x.Author.Surname != string.Empty);

            RuleFor(x => x.AuthorId).GreaterThan(0);

        }
    }
}
