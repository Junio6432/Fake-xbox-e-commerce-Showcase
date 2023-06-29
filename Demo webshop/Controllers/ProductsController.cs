using Demo_webshop.Models;
using Demo_webshop.Models.Services;
using Demo_webshop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data;
using System.IO.Pipelines;

namespace Demo_webshop.Controllers
{
    public class ProductsController: Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IGenreRepository _genreRepository;

        public ProductsController(IProductRepository productRepository, IGenreRepository genreRepository)
        {
            _productRepository = productRepository;
            _genreRepository = genreRepository;
        }


        public async Task<ViewResult> ListAsync(string genre)//Front not implemented yet
        {
            IEnumerable<Product> product;
            string? currentGenre;

            if (string.IsNullOrEmpty(genre))
            {
                await _productRepository.GetAllProductsAsync();

                product = _productRepository.AllProducts.OrderBy(p => p.ProductId);
                currentGenre = "All products";
            }
            else
            {
                product = _productRepository.AllProducts.Where(p => p.Genre.GenreName == genre)
                    .OrderBy(p => p.ProductId);
                await _genreRepository.GetAllGenresAsync();
                currentGenre = _genreRepository.AllGenres.FirstOrDefault(c => c.GenreName == genre)?.GenreName;
            }

            return View(new ProductListViewModel(product, currentGenre));
        }


        public async Task<IActionResult> DetailsAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [Authorize(Roles = "manager")]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            await _productRepository.GetAllProductsAsync();

            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct == null)
            {

                return NotFound();

            }
            else
            {
                await _productRepository.DeleteProductAsync(productId);

                return Json(new { message = "The product was deleted" });
            }
        }

    }
}
