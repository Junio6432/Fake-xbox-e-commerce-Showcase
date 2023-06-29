using System.IO.Pipelines;

namespace Demo_webshop.Models
{
    public class Genre
    {

        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Product>? Products { get; set; }

    }
}