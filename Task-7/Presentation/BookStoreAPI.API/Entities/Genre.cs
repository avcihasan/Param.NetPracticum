namespace BookStoreAPI.API.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsActive { get; set; } = true;
        public ICollection<Book> Books { get; set; }
    }
}
