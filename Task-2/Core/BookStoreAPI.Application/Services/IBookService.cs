using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.BookDTOs;
using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.Services
{
    public interface IBookService:IService<Book>
    {
        Task<CustomResponseDto<List<GetBookDto>>> GetAllBooksWithAllPropertiesAsync();
        Task<CustomResponseDto<GetBookDto>> GetBookByIdWithAllPropertiesAsync(int id);
        Task<CustomResponseDto<GetBookDto>> AddBookAsync(SetBookDto setBookDto);
        Task<CustomResponseDto<GetBookDto>> UpdateBookAsync(int id,SetBookDto setBookDto);
        Task<CustomResponseDto<List<GetBookDto>>> GetAllByPropertyNameToAscendingAsync(string propertyName);
        Task<CustomResponseDto<List<GetBookDto>>> GetAllByPropertyNameToDescendingAsync(string propertyName);

    }
}
