using AutoMapper;
using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.AuthorDTOs;
using BookStoreAPI.Application.DTOs.BookDTOs;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using BookStoreAPI.Domain.Entities;
using BookStoreAPI.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Persistence.Services
{
    public class AuthorService : Service<Author>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;
        public AuthorService(IGenericRepository<Author> repository, IAuthorRepository authorRepository, IMapper mapper, ILogger<AuthorService> logger) : base(repository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomResponseDto<GetAuthorDto>> AddAuthorAsync(SetAuthorDto setAuthorDto)
        {
            _logger.LogInformation("AddAuthorAsync tetiklendi");//loglama
            Author author = await _authorRepository.FilterByAuthorAsync(setAuthorDto.Name,setAuthorDto.Surname);
            if (author != null)
                return CustomResponseDto<GetAuthorDto>.Fail(400, "Yazar Ekli");
            author = _mapper.Map<Author>(setAuthorDto);
            await _authorRepository.AddAsync(author);
            await _authorRepository.SaveAsync();
            return CustomResponseDto<GetAuthorDto>.Success(201, _mapper.Map<GetAuthorDto>(author));


        }

        public async Task<CustomResponseDto<GetAuthorDto>> UpdateAuthorAsync(int id, SetAuthorDto setAuthorDto)
        {
            Author author =await _authorRepository.GetByIdAsync(id);
            if (author==null)
                return CustomResponseDto<GetAuthorDto>.Fail(404,"Yazar Bulunamadı");
            author = _mapper.Map<Author>(setAuthorDto);
            author.Id = id;
            bool result = _authorRepository.Update(author);
            if (!result)
                return CustomResponseDto<GetAuthorDto>.Fail(500, "Güncelleme Hatası");
            await _authorRepository.SaveAsync();
            return CustomResponseDto<GetAuthorDto>.Success(200,_mapper.Map<GetAuthorDto>(author));
        }
    }
}
