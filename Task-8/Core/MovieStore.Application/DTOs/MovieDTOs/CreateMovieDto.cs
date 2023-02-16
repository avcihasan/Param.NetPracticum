using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.DTOs.MovieDTOs
{
    public class CreateMovieDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public int GenreId { get; set; }

        public int DirectorId { get; set; }

    }
}
