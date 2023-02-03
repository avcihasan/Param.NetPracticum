using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "NumberOfPage is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int NumberOfPage { get; set; }

        [Required(ErrorMessage = "Price is required.")]    
        public decimal Price { get; set; }  
    }
}
