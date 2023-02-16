using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.DTOs.CustomerDTOs
{
    public class GetCustomerDto: BaseUserDto
    {
        public int Id{ get; set; }
        public ICollection<GetMovieDto>Movies { get; set; }
        //public ICollection<Genre> LikedGenres { get; set; }
    }
}
