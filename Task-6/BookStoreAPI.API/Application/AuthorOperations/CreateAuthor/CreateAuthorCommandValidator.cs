using FluentValidation;

namespace BookStoreAPI.API.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Author.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Author.Surname).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Author.Birthday).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
