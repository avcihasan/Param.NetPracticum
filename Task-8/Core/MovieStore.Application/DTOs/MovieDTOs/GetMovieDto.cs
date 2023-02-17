using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.DirectorDTOs;
using MovieStore.Application.DTOs.GenreDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.DTOs.MovieDTOs
{
    public class GetMovieDto:BaseDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public GetGenreDto Genre{ get; set; }

        public GetDirectorDto Director { get; set; }
        public ICollection<GetActorDto> Actors { get; set; }
    }
}
