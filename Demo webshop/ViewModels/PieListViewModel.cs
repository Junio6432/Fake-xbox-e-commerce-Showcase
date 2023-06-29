using Demo_webshop.Models;

namespace Demo_webshop.ViewModels
{
    public class ProductListViewModel
    {

        public IEnumerable<Product> Products { get; }
        public string? CurrentGenre { get; }

        public ProductListViewModel(IEnumerable<Product> product, string? currentGenre)
        {

            Products = product;
            CurrentGenre = currentGenre;

        }


    }
}
