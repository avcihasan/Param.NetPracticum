using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.DTOs.BookDTOs
{
    public class SetBookDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int NumberOfPage { get; set; }

        public decimal Price { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }
    }
}
