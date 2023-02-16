using AutoMapper;
using MovieStore.Application.DTOs.CustomerDTOs;
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
        }
    }
}
