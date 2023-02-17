using FluentValidation;
using MovieStore.Application.DTOs.ActorDTOs;

namespace MovieStore.Application.Validators.ActorValidators
{
    public class UpdateActorValidator:AbstractValidator<UpdateActorDto>
    {
        public UpdateActorValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ad alanını giriniz!")
                .MinimumLength(3)
                .WithMessage("Ad alanı en az 3 karakterden oluşmalıdır!");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Soyd alanını giriniz!")
                .MinimumLength(3)
                .WithMessage("Soyad alanı en az 3 karakterden oluşmalıdır!");
        }
    }
    }

