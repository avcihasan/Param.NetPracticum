using FluentValidation;
using MovieStore.Application.DTOs.MovieDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Validators.MovieValidators
{
    public class CreateMovieValidator:AbstractValidator<CreateMovieDto>
    {
        public CreateMovieValidator()
        {

            RuleFor(x => x.Name)
              .NotEmpty()
              .NotNull()
              .WithMessage("Ad alanını giriniz!")
              .MinimumLength(3)
              .WithMessage("Ad alanı en az 3 karakterden oluşmalıdır!");

            RuleFor(x => x.Year)
                .NotEmpty()
                .NotNull()
                .WithMessage("Yıl alanını giriniz!")
                .GreaterThan(1800)
                .WithMessage("1800 yılından büyük giriniz!")
                .LessThanOrEqualTo(DateTime.Now.Year )
                .WithMessage($"{DateTime.Now.Year } yılından küçük ya da eşit giriniz!");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Fiyat alanını giriniz!")
                .GreaterThan(0)
                .WithMessage("Fiyat alanını 0 dan büyük giriniz!");

            RuleFor(x => x.GenreId)
                .NotEmpty()
                .NotNull()
                .WithMessage("GenreId alanını giriniz!")
                .GreaterThan(0)
                .WithMessage("GenreId alanını 0 dan büyük giriniz!");

        }
    }
}
