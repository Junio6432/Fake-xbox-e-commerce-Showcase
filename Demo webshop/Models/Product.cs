namespace Demo_webshop.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? ESRB { get; set; }
        public decimal Price { get; set; }
        public string? Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsGameOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = default!;

    }
}
