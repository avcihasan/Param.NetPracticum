using AutoMapper;
using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.AuthorDTOs;
using BookStoreAPI.Application.DTOs.GenreDTOs;
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
    public class GenreService : Service<Genre>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;
        public GenreService(IGenericRepository<Genre> repository, IGenreRepository genreRepository, IMapper mapper, ILogger<AuthorService> logger) : base(repository)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomResponseDto<GetGenreDto>> AddGenreAsync(SetGenreDto setGenreDto)
        {
            _logger.LogInformation("AddGenreAsync tetiklendi");//loglama
            Genre genre = await _genreRepository.FilterByGenreAsync(setGenreDto.Name);
            if (_genreRepository != null)
                return CustomResponseDto<GetGenreDto>.Fail(400, "Tür Ekli");
            genre = _mapper.Map<Genre>(setGenreDto);
            await _genreRepository.AddAsync(genre);
            await _genreRepository.SaveAsync();
            return CustomResponseDto<GetGenreDto>.Success(201, _mapper.Map<GetGenreDto>(genre));
        }

        public async Task<CustomResponseDto<GetGenreDto>> UpdateGenreAsync(int id, SetGenreDto setGenreDto)
        {
            Genre genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
                return CustomResponseDto<GetGenreDto>.Fail(404, "Tür Bulunamadı");
            genre = _mapper.Map<Genre>(setGenreDto);
            genre.Id = id;
            bool result = _genreRepository.Update(genre);
            if (!result)
                return CustomResponseDto<GetGenreDto>.Fail(500, "Güncelleme Hatası");
            await _genreRepository.SaveAsync();
            return CustomResponseDto<GetGenreDto>.Success(200, _mapper.Map<GetGenreDto>(genre));

        }
    }
}
