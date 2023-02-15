using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.CreateAuthor;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthorById;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthors;
using BookStoreAPI.API.Application.BookOperations.GetBooks;
using BookStoreAPI.API.Application.GenreOperations.GetGenres;
using BookStoreAPI.API.Common;
using BookStoreAPI.API.Entities;
using static BookStoreAPI.API.Application.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreAPI.API.Application.BookOperations.GetBookById.GetBookByIdQuery;
using static BookStoreAPI.API.Application.GenreOperations.GetGenreById.GetGenreByIdQuery;

namespace BookStoreAPI.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewIdModel>();
            CreateMap<Book, BookViewModel>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorViewIdModel>();


            CreateMap<Genre, GenreViewIdModel>();
            CreateMap<Genre, GenreViewModel>();

        }
    }
    
}
