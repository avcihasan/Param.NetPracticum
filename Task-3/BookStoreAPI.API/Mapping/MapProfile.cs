using AutoMapper;
using BookStoreAPI.API.BookOperations.GetBooks;
using BookStoreAPI.API.Common;
using BookStoreAPI.API.Entities;
using static BookStoreAPI.API.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreAPI.API.BookOperations.GetBookByIdQuery.GetBooksByIdQuery;

namespace BookStoreAPI.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewIdModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
