using AutoMapper;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Application.DTOs.DirectorDTOs;
using MovieStore.Application.DTOs.GenreDTOs;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Movie, GetMovieDto>();
            CreateMap<UpdateMovieDto, Movie>();

            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, GetCustomerDto>();

            CreateMap<CreateActorDto, Actor>();
            CreateMap<Actor, GetActorDto>();
            CreateMap<UpdateActorDto, Actor>();

            CreateMap<CreateDirectorDto, Director>();
            CreateMap<Director, GetDirectorDto>();
            CreateMap<UpdateDirectorDto, Director>();


            CreateMap<Genre, GetGenreDto>();
        }
    }
}
