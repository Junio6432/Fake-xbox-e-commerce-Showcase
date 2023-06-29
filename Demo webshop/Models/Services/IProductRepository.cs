using System.IO.Pipelines;

namespace Demo_webshop.Models.Services
{
    public interface IProductRepository
    {

        IEnumerable<Product> AllProducts { get; }
        Task<IEnumerable<Product>> GameOfTheWeekAsync();
        Task<Product?> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchQuery);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task DeleteProductAsync(int productId);
    }
}
