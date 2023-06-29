using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace Demo_webshop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoWebShopDBContext _webDBContext;

        public ProductRepository(DemoWebShopDBContext webDBContext)
        {
            _webDBContext = webDBContext;
        }

        public IEnumerable<Product> AllProducts => _allProducts;
        private IEnumerable<Product> _allProducts = null!;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            _allProducts = await _webDBContext.Products.Include(c => c.Genre).ToListAsync();
            SetAllProducts(_allProducts);
            return _allProducts;
        }

        private void SetAllProducts(IEnumerable<Product> products)
        {
            _allProducts = products;
        }

        

        public async Task<IEnumerable<Product>> GameOfTheWeekAsync()
        {

           return await _webDBContext.Products.Include(c => c.Genre).Where(p => p.IsGameOfTheWeek).ToListAsync();

        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {

            return  await _webDBContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId); 
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchQuery)
        {
            return await _webDBContext.Products.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToListAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {

            var product = await _webDBContext
                .Products
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            _webDBContext.Products.RemoveRange(product);

            await _webDBContext.SaveChangesAsync();
        }

        

    }
}
