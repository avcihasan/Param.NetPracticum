using FluentValidation;
using MovieStore.Application.DTOs.DirectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Validators.DirectorValidators
{
    internal class CreateDirectorValidator:AbstractValidator<CreateDirectorDto>
    {
        public CreateDirectorValidator()
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
