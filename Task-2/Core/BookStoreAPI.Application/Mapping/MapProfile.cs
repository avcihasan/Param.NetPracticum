using AutoMapper;
using BookStoreAPI.Application.DTOs.AuthorDTOs;
using BookStoreAPI.Application.DTOs.BookDTOs;
using BookStoreAPI.Application.DTOs.GenreDTOs;
using BookStoreAPI.Application.DTOs.UserDTOs;
using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<SetBookDto, Book>();

            CreateMap<Author, GetAuthorDto>();
            CreateMap<SetAuthorDto, Author>();


            CreateMap<Genre, GetGenreDto>();
            CreateMap<SetGenreDto, Genre>();

            CreateMap<SetUserDto, User>();
        }

    }
         
    }