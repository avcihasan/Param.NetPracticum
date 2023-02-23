using MovieStore.Application.DTOs.GenreDTOs;
using MovieStore.Application.DTOs.MovieDTOs;

namespace MovieStore.Application.DTOs.CustomerDTOs
{
    public class GetCustomerDto: BaseUserDto
    {
        public int Id{ get; set; }
        public ICollection<GetMovieDto>Movies { get; set; }
        public ICollection<GetGenreDto> LikedGenres { get; set; }
    }
}
