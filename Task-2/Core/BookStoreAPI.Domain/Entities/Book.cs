using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Domain.Entities
{
    public class Book:BaseEntity
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "NumberOfPage is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int NumberOfPage { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
