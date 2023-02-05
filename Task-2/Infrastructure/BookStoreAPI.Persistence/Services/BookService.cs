using AutoMapper;
using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.AuthorDTOs;
using BookStoreAPI.Application.DTOs.BookDTOs;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using BookStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Persistence.Services
{
    public class BookService : Service<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;
        //ioc containerdan inject işlemleri
        public BookService(IGenericRepository<Book> repository, IBookRepository bookRepository, IMapper mapper, ILogger<BookService> logger) : base(repository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomResponseDto<GetBookDto>> AddBookAsync(SetBookDto setBookDto)
        {
            _logger.LogInformation("AddBookAsync tetiklendi");//loglama
            Book book = await _bookRepository.FilterByNameAsync(setBookDto.Name);
            if (book != null)
                return CustomResponseDto<GetBookDto>.Fail(400, "Kitap Ekli");
            book = _mapper.Map<Book>(setBookDto);
            bool result=await _bookRepository.AddAsync(book);
            if (!result)
                return CustomResponseDto<GetBookDto>.Fail(400, "Kitap Eklenemedi");
            await _bookRepository.SaveAsync();
            return CustomResponseDto<GetBookDto>.Success(201,_mapper.Map<GetBookDto>(book));

        }

        public async Task<CustomResponseDto<List<GetBookDto>>> GetAllBooksWithAllPropertiesAsync()
        {
            _logger.LogInformation("GetAllBooksWithAllPropertiesAsync tetiklendi");//loglama
            List<Book> books=  await _bookRepository.GetAllBooksWithAllPropertiesAsync();
            List<GetBookDto> booksDto = _mapper.Map<List<GetBookDto>>(books);          
            return CustomResponseDto<List<GetBookDto>>.Success(200,booksDto);
        }

        public async Task<CustomResponseDto<GetBookDto>> GetBookByIdWithAllPropertiesAsync(int id)
        {
            _logger.LogInformation("GetBookByIdWithAllPropertiesAsync tetiklendi");//loglama
            Book book = await _bookRepository.GetBookByIdWithAllPropertiesAsync(id);
            if (book==null)
                return CustomResponseDto<GetBookDto>.Fail(404, "Kitap Yok");
            GetBookDto getBookDto = _mapper.Map<GetBookDto>(book);

            return CustomResponseDto<GetBookDto>.Success(200, getBookDto);
        }

        public async Task<CustomResponseDto<GetBookDto>> UpdateBookAsync(int id, SetBookDto setBookDto)
        {
            _logger.LogInformation("UpdateBookAsync tetiklendi");//loglama
            Book book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return CustomResponseDto<GetBookDto>.Fail(404, "Kitap Kayıtılı Değil");
            book = _mapper.Map<Book>(setBookDto);
            book.Id = id;
            bool result=_bookRepository.Update(book);
            if (!result)
                return CustomResponseDto<GetBookDto>.Fail(500, "Güncelleme Hatası");
            await _bookRepository.SaveAsync();
            return CustomResponseDto<GetBookDto>.Success(200);
        }

        public async Task<CustomResponseDto<List<GetBookDto>>> GetAllByPropertyNameToAscendingAsync(string propertyName)
        {
            _logger.LogInformation("GetAllByPropertyNameToDescendingAsync tetiklendi");//loglama
            List<Book> books =await _bookRepository.GetAllByPropertyNameToAscending(propertyName).ToListAsync();
            List<GetBookDto> booksDto = _mapper.Map<List<GetBookDto>>(books);
            return CustomResponseDto<List<GetBookDto>>.Success(200, booksDto);

        }

        public async Task<CustomResponseDto<List<GetBookDto>>> GetAllByPropertyNameToDescendingAsync(string propertyName)
        {
            _logger.LogInformation("GetAllByPropertyNameToDescendingAsync tetiklendi");//loglama
            List<Book> books = await _bookRepository.GetAllByPropertyNameToDescending(propertyName).ToListAsync();
            List<GetBookDto> booksDto = _mapper.Map<List<GetBookDto>>(books);
            return CustomResponseDto<List<GetBookDto>>.Success(200, booksDto);
        }
    }
}
