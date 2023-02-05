using BookStoreAPI.Application.DTOs.AuthorDTOs;
using BookStoreAPI.Application.DTOs.GenreDTOs;
using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.DTOs.BookDTOs
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int NumberOfPage { get; set; }
        public decimal Price { get; set; }
        public GetAuthorDto Author { get; set; }
        public GetGenreDto Genre { get; set; }
    }
}
